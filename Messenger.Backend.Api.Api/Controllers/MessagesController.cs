using AutoMapper;
using Messenger.Backend.Api.Api.Models.Message;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.CreateMessage;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.DeleteMessage;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.UpdateMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class MessagesController : BaseController
    {
        private readonly IMapper _mapper;

        public MessagesController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Creates the message
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /message
        /// {
        ///     body: "message body"
        /// }
        /// </remarks>
        /// <param name="createMessageDto">CreateMessageDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMessageDto createMessageDto)
        {
            var command = _mapper.Map<CreateMessageCommand>(createMessageDto);
            command.UserId = UserId.ToString();
            var chatId = await Mediator.Send(command);
            return Ok(chatId);
        }

        /// <summary>
        /// Updates the message
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /message
        /// {
        ///     body: "updated message body"
        /// }
        /// </remarks>
        /// <param name="updateMessageDto">UpdateMessageDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDto updateMessageDto)
        {
            var command = _mapper.Map<UpdateMessageCommand>(updateMessageDto);
            command.UserId = UserId.ToString();
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the message by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /message/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="deleteMessageDto">DeleteMessageDto odject</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] DeleteMessageDto deleteMessageDto)
        {
            var command = _mapper.Map<DeleteMessageCommand>(deleteMessageDto);
            command.UserId = UserId.ToString();
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
