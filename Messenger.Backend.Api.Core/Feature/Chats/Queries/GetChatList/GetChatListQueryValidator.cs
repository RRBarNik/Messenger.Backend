using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Queries.GetChatList
{
    public class GetChatListQueryValidator : AbstractValidator<GetChatListQuery>
    {
        public GetChatListQueryValidator()
        {
            RuleFor(chat => chat.UserId).NotEqual(string.Empty);
        }
    }
}
