using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler
        : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IMessengerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMessengerDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {

            var usersQuery = await _dbContext.Users
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = usersQuery };
        }
    }
}
