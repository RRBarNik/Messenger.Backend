using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Users.Commands.CreateUser;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Backend.Api.Api.Models.User
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        /// <summary>
        /// Никнейм пользователя.
        /// </summary>
        [Required]
        public string Nickname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Lastname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Nickname,
                    opt => opt.MapFrom(userDto => userDto.Nickname))
                .ForMember(userCommand => userCommand.Firstname,
                    opt => opt.MapFrom(userDto => userDto.Firstname))
                .ForMember(userCommand => userCommand.Lastname,
                    opt => opt.MapFrom(userDto => userDto.Lastname));
        }
    }
}
