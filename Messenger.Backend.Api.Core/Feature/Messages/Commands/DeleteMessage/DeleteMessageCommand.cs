using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommand : IRequest
    {
        /// <summary>
        /// Идентификатор пользователя, который создал сообщение
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Идентификатор чата, к которому относится сообщение
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }
    }
}
