using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Entities;
using System;

namespace Messenger.Backend.Api.Core.Feature.Messages.Queries.GetMessageList
{
    public class MessageLookupDto : IMapWith<Message>
    {
        /// <summary>
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageLookupDto>()
                .ForMember(messageDto => messageDto.DateOfCreation,
                    opt => opt.MapFrom(message => message.DateOfCreation))
                .ForMember(messageDto => messageDto.Body,
                    opt => opt.MapFrom(message => message.Body));
        }
    }
}
