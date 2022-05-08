using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Chats.Queries.GetChatList
{
    public class GetChatListQuery : IRequest<ChatListVm>
    {
        public Guid UserId { get; set; }
    }
}
