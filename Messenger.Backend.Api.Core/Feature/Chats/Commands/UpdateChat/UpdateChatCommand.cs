using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.UpdateChat
{
    public class UpdateChatCommand : IRequest
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Новое имя
        /// </summary>
        public string Name { get; set; }
    }
}
