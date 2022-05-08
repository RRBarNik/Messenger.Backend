using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.DeleteUser
{
    public class DeleteUserCommand :IRequest
    {
        public Guid UserId { get; set; }
    }
}
