using MediatR;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResultVm>
    {
        /// <summary>
        /// Емайл пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }
    }
}
