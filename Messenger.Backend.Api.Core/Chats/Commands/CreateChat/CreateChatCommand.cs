using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Chats.Commands.CreateChat
{
    public class CreateChatCommand : IRequest<Guid>
    {
        /// <summary>
        /// Имя чата.
        /// </summary>
        public string Name { get; set; }
    }
}
