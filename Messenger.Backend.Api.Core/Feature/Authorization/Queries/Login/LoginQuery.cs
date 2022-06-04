﻿using MediatR;
using Messenger.Backend.Api.Core.Entities;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginQuery : IRequest<LoginResultVm>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
