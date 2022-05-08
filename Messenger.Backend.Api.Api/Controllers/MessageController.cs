using AutoMapper;
using Messenger.Backend.Api.Api.Models.Message;
using Messenger.Backend.Api.Core.Messages.Commands.CreateMessage;
using Messenger.Backend.Api.Core.Messages.Commands.DeleteMessage;
using Messenger.Backend.Api.Core.Messages.Commands.UpdateMessage;
using Messenger.Backend.Api.Core.Messages.Queries.GetMessageList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class MessageController : BaseController
    {
        private readonly IMapper _mapper;

        public MessageController(IMapper mapper) =>
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMessageDto createMessageDto)
        {
            var command = _mapper.Map<CreateMessageCommand>(createMessageDto);
            command.UserId = Guid.Parse("351a3466-21eb-419e-a0ea-4e282124c318");
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDto updateMessageDto)
        {
            var command = _mapper.Map<UpdateMessageCommand>(updateMessageDto);
            command.UserId = Guid.Parse("351a3466-21eb-419e-a0ea-4e282124c318");
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageDto deleteMessageDto)
        {
            var command = _mapper.Map<DeleteMessageCommand>(deleteMessageDto);
            command.UserId = Guid.Parse("351a3466-21eb-419e-a0ea-4e282124c318");
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
