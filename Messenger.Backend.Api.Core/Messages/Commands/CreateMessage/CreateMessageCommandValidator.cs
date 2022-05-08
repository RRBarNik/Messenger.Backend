using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(createMessageCommand =>
                createMessageCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand =>
                createMessageCommand.ChatId).NotEqual(Guid.Empty);
            RuleFor(createMessageCommand =>
                createMessageCommand.Body).NotEmpty();
        }
    }
}
