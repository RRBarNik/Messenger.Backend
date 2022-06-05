using AutoMapper;
using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Common.Exceptions;
using Messenger.Backend.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Commands.Register
{
    public class RegisterHandler
            : IRequestHandler<RegisterCommand, RegisterResultVm>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMessengerDbContext _dbContext;
        private readonly IMapper _mapper;

        public RegisterHandler(UserManager<AppUser> userManager, 
            IJwtGenerator jwtGenerator,
            IMessengerDbContext dbContext,
            IMapper mapper)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RegisterResultVm> Handle(RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new AuthenticationException("User with this email address already exists");
            }

            var newUser = new AppUser
            {
                Email = request.Email,
                UserName = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DateOfCreation = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                throw new AuthenticationException(
                    string.Join(",", createdUser.Errors.Select(x => x.Description)));
            }

            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user =>
                user.Id == newUser.Id, cancellationToken);

            var tokens = await _jwtGenerator.CreateTokenAsync(entity, cancellationToken);
            var userDto = _mapper.Map<RegisterUserDto>(entity);

            return new RegisterResultVm
            {
                AccessToken = tokens.Token,
                RefreshToken = tokens.RefreshToken,
                User = userDto
            };
        }
    }
}
