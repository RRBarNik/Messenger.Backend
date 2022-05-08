using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand =>
                deleteUserCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
