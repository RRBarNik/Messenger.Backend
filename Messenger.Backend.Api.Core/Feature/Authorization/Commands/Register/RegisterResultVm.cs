namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterResultVm
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public RegisterUserDto User { get; set; }
    }
}
