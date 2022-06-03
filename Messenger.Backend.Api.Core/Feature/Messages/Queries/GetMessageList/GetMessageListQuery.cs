using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid ChatId { get; set; }
    }
}
