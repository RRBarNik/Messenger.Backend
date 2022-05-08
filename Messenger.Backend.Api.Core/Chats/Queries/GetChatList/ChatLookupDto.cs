using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Chats.Queries.GetChatList
{
    public class ChatLookupDto : IMapWith<Chat>
    {
        /// <summary>
        /// Ид чата.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя чата.
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
