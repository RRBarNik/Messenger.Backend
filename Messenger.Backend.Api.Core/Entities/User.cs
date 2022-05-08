using System;
using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Entities
{
    public class User
    {
        /// <summary>
        /// Ид пользователя.
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// Роль.
        /// </summary>
        public string Role { get; set; }
        //TODO: change to enum

        /// <summary>
        /// Роль.
        /// </summary>
        public string ActiveStatus { get; set; }
        //TODO: change to enum

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        public List<Message> Messages { get; set; } = new();
    }
}
