using System;

namespace Messenger.Backend.Api.Core.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }

        /// <summary>
        /// Идентификатор чата, к которому относиться сообщение
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Чат, к которому относиться сообщение
        /// </summary>
        public Chat? Chat { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который создал сообщение
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь, который создал сообщение
        /// </summary>
        public User? User { get; set; }
    }
}
