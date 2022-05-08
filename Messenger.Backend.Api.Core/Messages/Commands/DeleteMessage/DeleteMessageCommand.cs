using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommand : IRequest
    {
        public Guid UserId { get; set; }

        public Guid ChatId { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }
    }
}
