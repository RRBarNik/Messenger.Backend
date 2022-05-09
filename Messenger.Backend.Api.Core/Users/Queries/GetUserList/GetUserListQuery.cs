using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
