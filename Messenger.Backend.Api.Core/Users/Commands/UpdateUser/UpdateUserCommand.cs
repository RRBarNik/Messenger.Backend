using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }
    }
}
