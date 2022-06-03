using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Feature.Chats.Queries.GetChatList
{
    public class ChatLookupDto : IMapWith<Chat>
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chat, ChatLookupDto>()
                .ForMember(chatDto => chatDto.Id,
                    opt => opt.MapFrom(chat => chat.Id))
                .ForMember(chatDto => chatDto.Name,
                    opt => opt.MapFrom(chat => chat.Name));
        }
    }
}
