using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// Никнейм пользователя.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Lastname { get; set; }
    }
}
