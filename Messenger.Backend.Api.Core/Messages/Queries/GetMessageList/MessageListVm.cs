using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Messages.Queries.GetMessageList
{
    public class MessageListVm
    {
        public IList<MessageLookupDto> Messages { get; set; }
    }
}
