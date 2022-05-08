using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMessengerDbContext _dbContext;

        public CreateUserCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.UserId,
                Nickname = request.Nickname,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DateOfCreation = DateTime.Now
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
