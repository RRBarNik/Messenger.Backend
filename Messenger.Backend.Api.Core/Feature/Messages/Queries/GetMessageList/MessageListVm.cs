using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Feature.Messages.Queries.GetMessageList
{
    public class MessageListVm
    {
        /// <summary>
        /// Список сообщений
        /// </summary>
        public IList<MessageLookupDto> Messages { get; set; }
    }
}
