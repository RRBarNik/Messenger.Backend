using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.RefreshToken
{
    public class RefreshTokenQueryHandler
        : IRequestHandler<RefreshTokenQuery, AuthenticationResult>
    {
        public readonly IMessengerDbContext _dbContext;
        public readonly UserManager<AppUser> _userManager;
        public readonly IJwtGenerator _jwtGenerator;
        public readonly IConfiguration Configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public RefreshTokenQueryHandler(IMessengerDbContext dbContext, 
            UserManager<AppUser> userManager,
            IJwtGenerator jwtGenerator,
            IConfiguration configuration,
            TokenValidationParameters tokenValidationParameters)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            Configuration = configuration;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthenticationResult> Handle(RefreshTokenQuery request,
            CancellationToken cancellationToken)
        {
            var validatedToken = GetPrincipalFromToken(request.Token);

            if (validatedToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "InvalidToken" } };
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.
                    Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix)
                .Subtract(TimeSpan.Parse(Configuration["JwtSettings:TokenLifetime"]));

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This token hasn't expired yet" }
                };
            }

            var jti = validatedToken.Claims.
                    Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _dbContext.RefreshTokens
                .SingleOrDefaultAsync(x => x.Token == request.RefreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This refresh token does not exist" }
                };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This refresh token has expired" }
                };
            }

            if (storedRefreshToken.Invalidated)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This refresh token has been invalidated" }
                };
            }

            if (storedRefreshToken.Used)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This refresh token has been used" }
                };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "This refresh token does not match this JWT" }
                };
            }

            storedRefreshToken.Used = true;
            _dbContext.RefreshTokens.Remove(storedRefreshToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var user = await _userManager.FindByIdAsync(
                validatedToken.Claims.Single(x => x.Type == "id").Value);

            return await _jwtGenerator.CreateTokenAsync(user, cancellationToken);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHanlder = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHanlder.ValidateToken(token,
                    _tokenValidationParameters,
                    out var validatedToken);
                if (!IsJwtValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
