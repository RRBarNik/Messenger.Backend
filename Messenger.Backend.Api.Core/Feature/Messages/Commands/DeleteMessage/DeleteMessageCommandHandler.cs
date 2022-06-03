using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Messages.Commands.DeleteMessage
{
    public class DeleteMessageCommandHandler
        : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public DeleteMessageCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteMessageCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages
                .FindAsync(new object[] { request.UserId, request.ChatId, request.DateOfCreation },
                    cancellationToken);

            if (entity == null 
                 || entity.UserId != request.UserId
                 || entity.ChatId != request.ChatId
                 || entity.DateOfCreation != request.DateOfCreation)
            {
                throw new NotFoundException(nameof(Message),
                    new object[] { request.UserId, request.ChatId, request.DateOfCreation });
            }

            _dbContext.Messages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
