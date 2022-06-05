using AutoMapper;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, LoginResultVm>
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly IJwtGenerator _jwtGenerator;
        public readonly IMapper _mapper;

        public LoginQueryHandler(UserManager<AppUser> userManager,
            IJwtGenerator jwtGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<LoginResultVm> Handle(LoginQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new AuthenticationException("User does not exist!");
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword)
            {
                throw new AuthenticationException("User/password combination is wrong");
            }

            var tokens = await _jwtGenerator.CreateTokenAsync(user, cancellationToken);
            var userDto = _mapper.Map<LoginUserDto>(user);


            return new LoginResultVm
            {
                AccessToken = tokens.Token,
                RefreshToken = tokens.RefreshToken,
                User = userDto
            };
        }
    }
}
