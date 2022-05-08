using System;

namespace Messenger.Backend.Api.Core.Abstractions
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
