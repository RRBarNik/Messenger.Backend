using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ChatId { get; set; }

        public string Body { get; set; }
    }
}
