using AutoMapper;
using Messenger.Backend.Api.Api.Models.Chat;
using Messenger.Backend.Api.Core.Chats.Commands.CreateChat;
using Messenger.Backend.Api.Core.Chats.Commands.DeleteChat;
using Messenger.Backend.Api.Core.Chats.Commands.UpdateChat;
using Messenger.Backend.Api.Core.Chats.Queries.GetChatList;
using Messenger.Backend.Api.Core.Messages.Commands.CreateMessage;
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
    public class ChatController : BaseController
    {
        private readonly IMapper _mapper;

        public ChatController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of chats
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /chat
        /// </remarks>
        /// <returns>Returns ChatListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ChatListVm>> GetAll()
        {
            var query = new GetChatListQuery
            {
                UserId = Guid.Parse("351a3466-21eb-419e-a0ea-4e282124c318"),
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of messages
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /message
        /// </remarks>
        /// <returns>Returns MessageListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{chatId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MessageListVm>> Get(Guid chatId)
        {
            var query = new GetMessageListQuery
            {
                ChatId = chatId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the Chat
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /chat
        /// {
        ///     name: "name of chat"
        /// }
        /// </remarks>
        /// <param name="createChatDto">CreateChatDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateChatDto createChatDto)
        {
            var chatCommand = _mapper.Map<CreateChatCommand>(createChatDto);
            var chatId = await Mediator.Send(chatCommand);
            return Ok(chatId);
        }

        /// <summary>
        /// Updates the chat
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /chat
        /// {
        ///     name: "updated chat name"
        /// }
        /// </remarks>
        /// <param name="updateChatDto">UpdateChatDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateChatDto updateChatDto)
        {
            var command = _mapper.Map<UpdateChatCommand>(updateChatDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the chat by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE chat/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the chat (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteChatCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
