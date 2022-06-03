using AutoMapper;
using Messenger.Backend.Api.Core.Authorization.Commands.Register;
using Messenger.Backend.Api.Core.Authorization.Queries.Login;
using Messenger.Backend.Api.Core.Authorization.Queries.RefreshToken;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class IdentityController : BaseController
    {
        private readonly IMapper _mapper;

        public IdentityController(IMapper mapper) =>
            _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
