namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterResultVm
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public RegisterUserDto User { get; set; }
    }
}
