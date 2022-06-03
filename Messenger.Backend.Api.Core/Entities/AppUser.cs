using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Entities
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        /// <summary>
        /// Список сообщений, созданных пользователем
        /// </summary>
        public List<Message> Messages { get; set; } = new();
    }
}
