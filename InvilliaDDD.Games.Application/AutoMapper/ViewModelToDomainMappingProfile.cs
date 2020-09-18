using AutoMapper;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.GameManager.Domain.Commands.Games;

namespace InvilliaDDD.GameManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GameViewModel, RegisterNewGameCommand>()
                .ConstructUsing(c => new RegisterNewGameCommand(c.Id, c.Name));
            CreateMap<GameViewModel, UpdateGameCommand>()
                .ConstructUsing(c => new UpdateGameCommand(c.Id, c.Name));
        }
    }
}
