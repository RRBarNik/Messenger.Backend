namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginResultVm
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
        public LoginUserDto User { get; set; }
    }
}
