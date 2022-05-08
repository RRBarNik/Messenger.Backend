using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public Guid UserId { get; set; }
    }
}
