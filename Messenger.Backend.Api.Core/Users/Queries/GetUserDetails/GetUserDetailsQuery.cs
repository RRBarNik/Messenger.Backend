using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
