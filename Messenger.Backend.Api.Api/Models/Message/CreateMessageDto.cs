using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.CreateMessage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Backend.Api.Api.Models.Message
{
    /// <summary>
    /// Dto для создания сообщения
    /// </summary>
    public class CreateMessageDto : IMapWith<CreateMessageCommand>
    {
        /// <summary>
        /// Тело сообщения
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Идентфикатор чата, к которому относится сообщение
        /// </summary>
        public Guid ChatId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMessageDto, CreateMessageCommand>()
                .ForMember(messageCommand => messageCommand.Body,
                    opt => opt.MapFrom(messageDto => messageDto.Body))
                .ForMember(messageCommand => messageCommand.ChatId,
                    opt => opt.MapFrom(messageDto => messageDto.ChatId));
        }
    }
}
