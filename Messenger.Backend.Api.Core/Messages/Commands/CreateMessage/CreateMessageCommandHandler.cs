using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandHandler
        : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IMessengerDbContext _dbContext;

        public CreateMessageCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateMessageCommand request,
            CancellationToken cancellationToken)
        {
            var message = new Message
            {
                UserId = request.UserId,
                ChatId = request.ChatId,
                Body = request.Body,
                DateOfCreation = DateTimeOffset.Now
            };

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.ChatId;
        }
    }
}
