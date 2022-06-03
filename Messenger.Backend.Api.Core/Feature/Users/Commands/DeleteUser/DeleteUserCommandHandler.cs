using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public DeleteUserCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FindAsync(new object[] { request.UserId }, cancellationToken);

            if(entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(AppUser), request.UserId);
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
