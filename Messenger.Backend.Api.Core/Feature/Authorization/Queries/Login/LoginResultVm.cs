namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginResultVm
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public LoginUserDto User { get; set; }
    }
}
