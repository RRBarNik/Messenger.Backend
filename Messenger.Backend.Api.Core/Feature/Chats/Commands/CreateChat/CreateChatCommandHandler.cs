using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Chats.Commands.CreateChat
{
    public class CreateChatCommandHandler
        : IRequestHandler<CreateChatCommand, Guid>
    {
        private readonly IMessengerDbContext _dbContext;

        public CreateChatCommandHandler(IMessengerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateChatCommand request,
            CancellationToken cancellationToken)
        {
            var chat = new Chat
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _dbContext.Chats.AddAsync(chat, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return chat.Id;
        }
    }
}
