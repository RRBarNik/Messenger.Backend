using AutoMapper;
using Messenger.Backend.Api.Api.Models.User;
using Messenger.Backend.Api.Core.Feature.Users.Commands.DeleteUser;
using Messenger.Backend.Api.Core.Feature.Users.Commands.UpdateUser;
using Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserDetails;
using Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /users
        /// </remarks>
        /// <returns>Returns UserListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /user/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">User id (guid)</param>
        /// <returns>Returns UserDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = id.ToString(),
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /user
        /// {
        ///     nickname: "updated User Nickname",
        ///     firstname: "updated User Firstname",
        ///     lastname: "updated User Lastname"
        /// }
        /// </remarks>
        /// <param name="updateUserDto">UpdateUserDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /user/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the user (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteUserCommand
            {
                UserId = id.ToString(),
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
