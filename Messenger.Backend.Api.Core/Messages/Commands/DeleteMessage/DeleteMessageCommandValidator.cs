using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator()
        {
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.ChatId).NotEqual(Guid.Empty);
            RuleFor(deleteMessageCommand =>
                deleteMessageCommand.DateOfCreation).NotNull();
        }
    }
}
