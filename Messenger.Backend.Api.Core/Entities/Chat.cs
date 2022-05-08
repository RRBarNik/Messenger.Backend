using System;
using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Entities
{
    public class Chat
    {
        /// <summary>
        /// Ид чата.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя чата.
        /// </summary>
        public string Name { get; set; }

        public List<Message> Messages { get; set; } = new();

        //public ICollection<User> Users { get; set; }
    }
}
