using AutoMapper;
using Messenger.Backend.Api.Core.Chats.Commands.UpdateChat;
using Messenger.Backend.Api.Core.Common.Mappings;
using System;

namespace Messenger.Backend.Api.Api.Models.Chat
{
    /// <summary>
    /// Dto для обновления чата
    /// </summary>
    public class UpdateChatDto : IMapWith<UpdateChatCommand>
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Новое имя чата
        /// </summary>
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateChatDto, UpdateChatCommand>()
                .ForMember(userCommand => userCommand.Id,
                    opt => opt.MapFrom(userDto => userDto.Id))
                .ForMember(userCommand => userCommand.Name,
                    opt => opt.MapFrom(userDto => userDto.Name));
        }
    }
}
