using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand =>
                updateUserCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateUserCommand =>
                updateUserCommand.Nickname).NotEmpty();
        }
    }
}
