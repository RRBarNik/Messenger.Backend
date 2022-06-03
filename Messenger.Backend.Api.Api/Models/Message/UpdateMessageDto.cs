using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.UpdateMessage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Backend.Api.Api.Models.Message
{
    /// <summary>
    /// Dto для обновления сообщения
    /// </summary>
    public class UpdateMessageDto : IMapWith<UpdateMessageCommand>
    {
        /// <summary>
        /// Идентификатор чата, к которому относится сообщение
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }

        /// <summary>
        /// Новое тело сообщения
        /// </summary>
        [Required]
        public string Body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMessageDto, UpdateMessageCommand>()
                .ForMember(messageCommand => messageCommand.ChatId,
                    opt => opt.MapFrom(messageDto => messageDto.ChatId))
                .ForMember(messageCommand => messageCommand.DateOfCreation,
                    opt => opt.MapFrom(messageDto => messageDto.DateOfCreation))
                .ForMember(messageCommand => messageCommand.Body,
                    opt => opt.MapFrom(messageDto => messageDto.Body));
        }
    }
}
