using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Chats.Queries.GetChatList
{
    public class GetChatListQueryHandler
        : IRequestHandler<GetChatListQuery, ChatListVm>
    {
        private readonly IMessengerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetChatListQueryHandler(IMessengerDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ChatListVm> Handle(GetChatListQuery request,
            CancellationToken cancellationToken)
        {
            var chatsQuery = await _dbContext.Messages
                .Where(pt => pt.UserId == request.UserId)
                .Select(pt => pt.Chat)
                .ProjectTo<ChatLookupDto>(_mapper.ConfigurationProvider)
                .Distinct()
                .ToListAsync(cancellationToken);

            return new ChatListVm { Chats = chatsQuery };
        }
    }
}
