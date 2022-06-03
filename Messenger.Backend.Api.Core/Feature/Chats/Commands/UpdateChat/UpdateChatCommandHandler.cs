using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.UpdateChat
{
    public class UpdateChatCommandHandler
        : IRequestHandler<UpdateChatCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public UpdateChatCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateChatCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Chats.FirstOrDefaultAsync(chat =>
                    chat.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Chat), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
