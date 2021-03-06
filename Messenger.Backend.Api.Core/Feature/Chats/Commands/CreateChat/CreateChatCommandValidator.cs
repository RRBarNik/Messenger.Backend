using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.CreateChat
{
    public class CreateChatCommandValidator : AbstractValidator<CreateChatCommand>
    {
        public CreateChatCommandValidator()
        {
            RuleFor(createChatCommand =>
                createChatCommand.Name).NotNull();
        }
    }
}
