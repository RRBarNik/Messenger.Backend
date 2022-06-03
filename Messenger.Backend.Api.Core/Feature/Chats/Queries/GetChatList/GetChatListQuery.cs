using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Queries.GetChatList
{
    public class GetChatListQuery : IRequest<ChatListVm>
    {
        public string UserId { get; set; }
    }
}
