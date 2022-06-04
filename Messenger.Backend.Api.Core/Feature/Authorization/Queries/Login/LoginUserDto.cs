using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;

namespace Messenger.Backend.Api.Core.Feature.Authorization.Queries.Login
{
    public class LoginUserDto : IMapWith<AppUser>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Никнейм
        /// </summary>
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, LoginUserDto>()
                .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Firstname,
                opt => opt.MapFrom(user => user.Firstname))
                .ForMember(userDto => userDto.Lastname,
                opt => opt.MapFrom(user => user.Lastname))
                .ForMember(userDto => userDto.Email,
                opt => opt.MapFrom(user => user.Email));
        }
    }
}
