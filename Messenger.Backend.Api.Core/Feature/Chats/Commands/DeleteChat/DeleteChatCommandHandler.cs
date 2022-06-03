using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandHandler
        : IRequestHandler<DeleteChatCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public DeleteChatCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteChatCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Chats
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Chat), request.Id);
            }

            _dbContext.Chats.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
