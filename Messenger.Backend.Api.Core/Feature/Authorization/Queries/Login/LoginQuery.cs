using MediatR;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginQuery : IRequest<LoginResultVm>
    {
        /// <summary>
        /// Емайл пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
