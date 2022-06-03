using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Feature.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<AppUser>
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
        public string UserName { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Firstname,
                    opt => opt.MapFrom(user => user.Firstname))
                .ForMember(userVm => userVm.Lastname,
                    opt => opt.MapFrom(user => user.Lastname))
                .ForMember(userVm => userVm.UserName,
                    opt => opt.MapFrom(user => user.UserName))
                .ForMember(userVm => userVm.DateOfCreation,
                    opt => opt.MapFrom(user => user.DateOfCreation));
        }
    }
}
