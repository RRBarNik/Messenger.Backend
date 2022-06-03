using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Messages.Queries.GetMessageList
{
    public class GetMessageListQueryHandler
        : IRequestHandler<GetMessageListQuery, MessageListVm>
    {
        private readonly IMessengerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IMessengerDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MessageListVm> Handle(GetMessageListQuery request,
            CancellationToken cancellationToken)
        {
            var messagesQuery = await _dbContext.Messages
                .Where(message => message.ChatId == request.ChatId)
                .ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MessageListVm { Messages = messagesQuery };
        }
    }
}
