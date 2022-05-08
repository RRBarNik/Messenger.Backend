using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Messages.Commands.UpdateMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Api.Models.Message
{
    public class UpdateMessageDto : IMapWith<UpdateMessageCommand>
    {
        public Guid ChatId { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }

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
