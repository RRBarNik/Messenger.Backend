using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Никнейм пользователя.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public string Role { get; set; }
        //TODO: change to enum

        /// <summary>
        /// Роль.
        /// </summary>
        public string ActiveStatus { get; set; }
        //TODO: change to enum

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Nickname,
                    opt => opt.MapFrom(user => user.Nickname))
                .ForMember(userVm => userVm.Firstname,
                    opt => opt.MapFrom(user => user.Firstname))
                .ForMember(userVm => userVm.Lastname,
                    opt => opt.MapFrom(user => user.Lastname))
                .ForMember(userVm => userVm.Role,
                    opt => opt.MapFrom(user => user.Role))
                .ForMember(userVm => userVm.ActiveStatus,
                    opt => opt.MapFrom(user => user.ActiveStatus))
                .ForMember(userVm => userVm.DateOfCreation,
                    opt => opt.MapFrom(user => user.DateOfCreation));
        }
    }
}
