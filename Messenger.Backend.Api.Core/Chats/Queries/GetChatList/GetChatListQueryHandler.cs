using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Chats.Queries.GetChatList
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
                /*
                .FromSqlInterpolated(
@$"SELECT m.chat_id, c.""name"", m.body, c.id
FROM public.messages AS m
LEFT OUTER JOIN public.chats AS c 
ON c.id  = m.chat_id 
WHERE m.user_id = {request.UserId}
AND m.date_of_creation
IN
(SELECT Max(m.date_of_creation)
FROM public.messages AS m
GROUP BY m.chat_id)")*/
                .Where(pt => pt.UserId == request.UserId)
                .Select(pt => pt.Chat)
                .ProjectTo<ChatLookupDto>(_mapper.ConfigurationProvider)
                .Distinct()
                .ToListAsync(cancellationToken);

            return new ChatListVm { Chats = chatsQuery };
        }
    }
}
