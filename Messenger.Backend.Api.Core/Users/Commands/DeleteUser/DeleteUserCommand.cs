using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.DeleteUser
{
    public class DeleteUserCommand :IRequest
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
