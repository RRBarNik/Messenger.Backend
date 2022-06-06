using MediatR;

namespace Messenger.Backend.Api.Core.Feature.Chats.Queries.GetChatList
{
    public class GetChatListQuery : IRequest<ChatListVm>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }
    }
}
