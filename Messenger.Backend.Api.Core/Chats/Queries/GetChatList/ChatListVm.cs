using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Chats.Queries.GetChatList
{
    public class ChatListVm
    {
        public IList<ChatLookupDto> Chats { get; set; }
    }
}
