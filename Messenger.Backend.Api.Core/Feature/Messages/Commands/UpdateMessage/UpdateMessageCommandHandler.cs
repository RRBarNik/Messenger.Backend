using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.UpdateMessage
{
    public class UpdateMessageCommandHandler
        : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public UpdateMessageCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateMessageCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Messages
                    .FirstOrDefaultAsync(message =>
                 message.UserId == request.UserId &&
                 message.ChatId == request.ChatId &&
                 message.DateOfCreation == request.DateOfCreation,
                 cancellationToken);

            if (entity == null 
                || entity.UserId != request.UserId
                || entity.ChatId != request.ChatId
                || entity.DateOfCreation != request.DateOfCreation)
            {
                throw new NotFoundException(nameof(Message),
                    new object[] { request.UserId, request.ChatId, request.DateOfCreation });
            }

            entity.Body = request.Body;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
