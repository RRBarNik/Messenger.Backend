using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Chats.Commands.DeleteChat
{
    public class DeleteChatCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
