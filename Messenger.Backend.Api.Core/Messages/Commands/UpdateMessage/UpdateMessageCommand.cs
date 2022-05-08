using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid ChatId { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }

        public string Body { get; set; }
    }
}
