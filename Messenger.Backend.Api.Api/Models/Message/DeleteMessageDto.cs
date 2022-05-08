using AutoMapper;
using Messenger.Backend.Api.Core.Common.Mappings;
using Messenger.Backend.Api.Core.Messages.Commands.DeleteMessage;
using System;

namespace Messenger.Backend.Api.Api.Models.Message
{
    public class DeleteMessageDto : IMapWith<DeleteMessageCommand>
    {
        public Guid ChatId { get; set; }

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
