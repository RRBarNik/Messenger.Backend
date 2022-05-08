using AutoMapper;
using Messenger.Backend.Api.Core.Chats.Commands.CreateChat;
using Messenger.Backend.Api.Core.Common.Mappings;

namespace Messenger.Backend.Api.Api.Models.Chat
{
    public class CreateChatDto : IMapWith<CreateChatCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateChatDto, CreateChatCommand>()
                .ForMember(userCommand => userCommand.Name,
                    opt => opt.MapFrom(userDto => userDto.Name));
        }
    }
}
