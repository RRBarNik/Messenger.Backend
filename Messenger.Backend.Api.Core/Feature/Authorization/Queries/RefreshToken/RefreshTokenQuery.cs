using MediatR;
using Messenger.Backend.Api.Core.Entities;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.RefreshToken
{
    public class RefreshTokenQuery : IRequest<AuthenticationResult>
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
