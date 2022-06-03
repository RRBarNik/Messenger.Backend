using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.UpdateChat
{
    public class UpdateChatCommandValidator : AbstractValidator<UpdateChatCommand>
    {
        public UpdateChatCommandValidator()
        {
            RuleFor(updateChatCommand =>
                updateChatCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateChatCommand =>
                updateChatCommand.Name).NotEmpty();
        }
    }
}
