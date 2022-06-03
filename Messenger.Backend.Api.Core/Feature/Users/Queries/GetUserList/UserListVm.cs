using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserList
{
    public class UserListVm
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        public IList<UserLookupDto> Users { get; set; }
    }
}
