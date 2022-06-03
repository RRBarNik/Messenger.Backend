using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Feature.Users.Commands.UpdateUser;
using System;

namespace Messenger.Backend.Api.Api.Models.User
{
    /// <summary>
    /// Dto для обновления пользователя
    /// </summary>
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Обновленное имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Обновленная фамилия
        /// </summary>
        public string Lastname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userCommand => userCommand.UserId,
                    opt => opt.MapFrom(userDto => userDto.UserId))
                .ForMember(userCommand => userCommand.Firstname,
                    opt => opt.MapFrom(userDto => userDto.Firstname))
                .ForMember(userCommand => userCommand.Lastname,
                    opt => opt.MapFrom(userDto => userDto.Lastname));
        }
    }
}
