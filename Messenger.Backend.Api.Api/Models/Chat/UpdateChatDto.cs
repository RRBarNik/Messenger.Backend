using AutoMapper;
using Messenger.Backend.Api.Core.Chats.Commands.UpdateChat;
using Messenger.Backend.Api.Core.Common.Mappings;
using System;

namespace Messenger.Backend.Api.Api.Models.Chat
{
    public class UpdateChatDto : IMapWith<UpdateChatCommand>
    {
        /// <summary>
        /// Ид чата.
        /// </summary>
        public Guid Id { get; set; }

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
