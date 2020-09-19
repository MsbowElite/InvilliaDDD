using AutoMapper;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.GameManager.Domain.Commands.Friends;
using InvilliaDDD.GameManager.Domain.Commands.Games;

namespace InvilliaDDD.GameManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Game
            CreateMap<GameViewModel, RegisterNewGameCommand>()
                .ConstructUsing(c => new RegisterNewGameCommand(c.Id, c.Name));
            CreateMap<GameViewModel, UpdateGameCommand>()
                .ConstructUsing(c => new UpdateGameCommand(c.Id, c.Name));

            //Friend
            CreateMap<FriendViewModel, RegisterNewFriendCommand>()
                .ConstructUsing(c => new RegisterNewFriendCommand(c.Id, c.Name));
            CreateMap<FriendViewModel, UpdateFriendCommand>()
                .ConstructUsing(c => new UpdateFriendCommand(c.Id, c.Name));
        }
    }
}
