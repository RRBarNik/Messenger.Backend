using System;

namespace Messenger.Backend.Api.Core.Common.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message)
            : base(message) { }
    }
}
