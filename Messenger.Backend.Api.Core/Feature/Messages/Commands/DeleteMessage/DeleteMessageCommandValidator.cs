using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator()
        {
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.UserId).NotEqual(string.Empty);
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.ChatId).NotEqual(Guid.Empty);
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.DateOfCreation).NotNull();
        }
    }
}
