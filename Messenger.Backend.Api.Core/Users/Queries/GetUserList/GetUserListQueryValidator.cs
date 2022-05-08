using FluentValidation;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator()
        {
            RuleFor(user => user.UserId).NotEqual(Guid.Empty);
        }
    }
}
