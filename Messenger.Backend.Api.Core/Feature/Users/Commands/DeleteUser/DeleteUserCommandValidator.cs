using FluentValidation;

namespace Messenger.Backend.Api.Core.Feature.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand =>
                deleteUserCommand.UserId).NotEqual(string.Empty);
        }
    }
}
