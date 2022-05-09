using System;

namespace Messenger.Backend.Api.Core.Abstractions
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        Guid UserId { get; }
    }
}
