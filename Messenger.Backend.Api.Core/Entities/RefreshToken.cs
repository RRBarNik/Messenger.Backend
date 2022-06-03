using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Backend.Api.Core.Entities
{
    public class RefreshToken
    {
        /// <summary>
        /// Токен обновления
        /// </summary>
        [Key]
        public string Token { get; set; }

        /// <summary>
        /// Идентификатор токена доступа
        /// </summary>
        public string JwtId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата истечения времени жизни токена
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Был ли токен уже использован
        /// </summary>
        public bool Used { get; set; }

        /// <summary>
        /// Является ли токен недействительным
        /// </summary>
        public bool Invalidated { get; set; }

        /// <summary>
        /// Идентификатор пользователя, к которому принадлежит токен
        /// </summary>
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
