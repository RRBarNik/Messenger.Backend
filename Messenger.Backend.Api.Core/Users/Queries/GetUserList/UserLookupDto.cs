using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        /// <summary>
        /// Ид пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Никнейм пользователя.
        /// </summary>
        public string Nickname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Nickname,
                opt => opt.MapFrom(user => user.Nickname));
        }
    }
}
