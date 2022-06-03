using MediatR;
using Messenger.Backend.Api.Core.Entities;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterCommand : IRequest<AuthenticationResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
