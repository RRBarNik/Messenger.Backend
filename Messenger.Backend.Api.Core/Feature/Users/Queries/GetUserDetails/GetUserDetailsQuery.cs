using MediatR;

namespace Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string Id { get; set; }
    }
}
