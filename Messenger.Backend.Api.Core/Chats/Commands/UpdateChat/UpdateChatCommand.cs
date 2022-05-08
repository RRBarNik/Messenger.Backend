using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Chats.Commands.UpdateChat
{
    public class UpdateChatCommand : IRequest
    {
        /// <summary>
        /// Ид чата.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя чата.
        /// </summary>
        public string Name { get; set; }
    }
}
