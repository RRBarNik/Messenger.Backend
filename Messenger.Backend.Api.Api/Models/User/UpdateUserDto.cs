using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Users.Commands.UpdateUser;
using System;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Backend.Api.Api.Models.User
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public Guid UserId { get; set; }

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
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userCommand => userCommand.UserId,
                    opt => opt.MapFrom(userDto => userDto.UserId))
                .ForMember(userCommand => userCommand.Nickname,
                    opt => opt.MapFrom(userDto => userDto.Nickname))
                .ForMember(userCommand => userCommand.Firstname,
                    opt => opt.MapFrom(userDto => userDto.Firstname))
                .ForMember(userCommand => userCommand.Lastname,
                    opt => opt.MapFrom(userDto => userDto.Lastname));
        }
    }
}
