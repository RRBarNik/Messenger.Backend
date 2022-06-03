using FluentValidation;

namespace Messenger.Backend.Api.Core.Feature.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand =>
                updateUserCommand.UserId).NotEqual(string.Empty);
        }
    }
}
