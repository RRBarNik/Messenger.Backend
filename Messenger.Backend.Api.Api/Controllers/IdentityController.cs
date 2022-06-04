using AutoMapper;
using Messenger.Backend.Api.Core.Entities;
using Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register;
using Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login;
using Messenger.Backend.Api.Core.Feature.Authorization.Queries.RefreshToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/")]
    public class IdentityController : BaseController
    {
        private readonly IMapper _mapper;

        public IdentityController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Register the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /message
        /// {
        ///     email: "UserEmail",
        ///     password: "UserPassword#1#",
        ///     firstname: "firstname",
        ///     lastname: "lastname"
        /// }
        /// </remarks>
        /// <param name="request">RegisterCommnad object</param>
        /// <returns>Returns access token, refresh token and user information</returns>
        /// <response code="201">Success</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RegisterResultVm>> Register([FromBody] RegisterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Login the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /message
        /// {
        ///     email: "UserEmail",
        ///     password: "UserPassword#1#",
        /// }
        /// </remarks>
        /// <param name="request">LoginQuery object</param>
        /// <returns>Returns access token and refresh token</returns>
        /// <response code="200">Success</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResultVm>> Login([FromBody] LoginQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Refresh the tokens
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /message
        /// {
        ///     "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
        ///     eyJzdWIiOiJOaWtpdGEiLCJqdGkiOiIzZTYyNjczYS0zY2Y5LTQ0NDAtOTMzYy05OWZlMzdmNzMw.
        ///     21aFlF47XRRTz8Vi714qQW55tInJ0fgdD0SmK9IHjZs",
        ///     "refreshToken": "1cd48cea-8de8-47e2-9711-25ae8b68bb81"
        /// }
        /// </remarks>
        /// <param name="request">RefreshTokenQuery object</param>
        /// <returns>Returns new access token and refresh token</returns>
        /// <response code="200">Success</response>
        [HttpPost("refreshToken")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthenticationResult>> Refresh([FromBody] RefreshTokenQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
