using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Feature.Messages.Commands.DeleteMessage;
using System;

namespace Messenger.Backend.Api.Api.Models.Message
{
    /// <summary>
    /// Dto для удаления сообщения
    /// </summary>
    public class DeleteMessageDto : IMapWith<DeleteMessageCommand>
    {
        /// <summary>
        /// Идентификатор чата, к которому относится сообщение
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTimeOffset DateOfCreation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteMessageDto, DeleteMessageCommand>()
                .ForMember(messageCommand => messageCommand.ChatId,
                    opt => opt.MapFrom(messageDto => messageDto.ChatId))
                .ForMember(messageCommand => messageCommand.DateOfCreation,
                    opt => opt.MapFrom(messageDto => messageDto.DateOfCreation));
        }
    }
}
