using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterHandler
            : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public RegisterHandler(UserManager<AppUser> userManager, 
            IJwtGenerator jwtGenerator) =>
            (_userManager, _jwtGenerator) = (userManager, jwtGenerator);

        public async Task<AuthenticationResult> Handle(RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email address already exists" }
                };
            }

            var newUser = new AppUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return await _jwtGenerator.CreateTokenAsync(newUser, cancellationToken);
        }
    }
}
