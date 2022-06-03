using MediatR;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Guid>
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
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }
    }
}
