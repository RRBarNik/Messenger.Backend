using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandValidator : AbstractValidator<DeleteChatCommand>
    {
        public DeleteChatCommandValidator()
        {
            RuleFor(deleteChatCommand =>
                deleteChatCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
