using AutoMapper;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IMessengerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IMessengerDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
