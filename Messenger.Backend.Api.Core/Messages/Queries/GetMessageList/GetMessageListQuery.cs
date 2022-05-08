using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        public Guid ChatId { get; set; }
    }
}
