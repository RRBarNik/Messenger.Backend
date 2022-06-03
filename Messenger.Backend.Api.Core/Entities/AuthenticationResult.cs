using System.Collections.Generic;

namespace Messenger.Backend.Api.Core.Entities
{
    public class AuthenticationResult
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
