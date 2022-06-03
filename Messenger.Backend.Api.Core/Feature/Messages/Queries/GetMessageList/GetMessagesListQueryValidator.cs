using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Queries.GetMessageList
{
    public class GetMessagesListQueryValidator : AbstractValidator<GetMessageListQuery>
    {
        public GetMessagesListQueryValidator()
        {
            RuleFor(message => message.ChatId).NotEqual(Guid.Empty);
        }
    }
}
