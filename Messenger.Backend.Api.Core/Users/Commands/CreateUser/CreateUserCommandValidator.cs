using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createUserCommand =>
                createUserCommand.Nickname).NotEmpty();
        }
    }
}
