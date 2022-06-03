using FluentValidation;

namespace Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(user => user.Id).NotEqual(string.Empty);
        }
    }
}
