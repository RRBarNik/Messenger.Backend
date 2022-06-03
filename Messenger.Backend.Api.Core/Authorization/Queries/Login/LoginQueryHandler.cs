using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Authorization.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly IJwtGenerator _jwtGenerator;

        public LoginQueryHandler(UserManager<IdentityUser> userManager,
            IJwtGenerator jwtGenerator) =>
            (_userManager, _jwtGenerator) = (userManager, jwtGenerator);

        public async Task<AuthenticationResult> Handle(LoginQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist!" }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User/password combination is wrong" }
                };
            }

            return await _jwtGenerator.CreateTokenAsync(user, cancellationToken);
        }
    }
}
