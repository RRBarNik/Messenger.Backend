using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Messages.Commands.CreateMessage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Messenger.Backend.Api.Api.Models.Message
{
    public class CreateMessageDto : IMapWith<CreateMessageCommand>
    {
        [Required]
        public string Body { get; set; }

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
