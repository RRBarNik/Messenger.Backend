using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly IMessengerDbContext _dbContext;

        public UpdateUserCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.UserId, cancellationToken);

            if (entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(AppUser), request.UserId);
            }

            entity.Firstname = request.Firstname;
            entity.Lastname = request.Lastname;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
