using MediatR;

namespace Messenger.Backend.Api.Core.Feature.Users.Commands.DeleteUser
{
    public class DeleteUserCommand :IRequest
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}
