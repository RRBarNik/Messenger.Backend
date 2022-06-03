using Messenger.Backend.Api.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Abstractions
{
    public interface IJwtGenerator
    {
        Task<AuthenticationResult> CreateTokenAsync(AppUser user, 
            CancellationToken cancellationToken);
    }
}
