using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Chats.Queries.GetChatList
{
    public class ChatListVm
    {
        /// <summary>
        /// Список чатов
        /// </summary>
        public IList<ChatLookupDto> Chats { get; set; }
    }
}
