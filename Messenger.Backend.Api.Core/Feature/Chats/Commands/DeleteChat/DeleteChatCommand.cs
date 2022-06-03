using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.DeleteChat
{
    public class DeleteChatCommand : IRequest
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid Id { get; set; }
    }
}
