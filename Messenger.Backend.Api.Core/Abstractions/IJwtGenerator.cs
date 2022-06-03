using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Abstractions
{
    public interface IJwtGenerator
    {
        Task<AuthenticationResult> CreateTokenAsync(IdentityUser user, 
            CancellationToken cancellationToken);
    }
}
