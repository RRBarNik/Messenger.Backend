using System;
using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Entities
{
    /// <summary>
    /// Чат
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя чата
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список сообщений, которые содержаться в чате
        /// </summary>
        public List<Message> Messages { get; set; } = new();
    }
}
