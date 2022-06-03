using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidator()
        {
            RuleFor(updateMessageCommand =>
                   updateMessageCommand.UserId).NotEqual(string.Empty);
            RuleFor(updateMessageCommand =>
                   updateMessageCommand.ChatId).NotEqual(Guid.Empty);
            RuleFor(updateMessageCommand =>
                   updateMessageCommand.DateOfCreation).NotNull();
            RuleFor(updateMessageCommand =>
                   updateMessageCommand.Body).NotEmpty();
        }
    }
}
