using MediatR;
using Messenger.Backend.Api.Core.Entities;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.RefreshToken
{
    public class RefreshTokenQuery : IRequest<AuthenticationResult>
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
