using System;

namespace Messenger.Backend.Api.Core.Entities
{
    public class Message
    {
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Body { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }

        public Guid ChatId { get; set; }
        public Chat? Chat { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
