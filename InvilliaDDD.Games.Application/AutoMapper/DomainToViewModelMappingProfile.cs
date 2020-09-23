using AutoMapper;
using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.GameManager.Domain.Entities;

namespace InvilliaDDD.GameManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Game, GameViewModel>().ForMember(dest => dest.Borrowed, opt => opt.MapFrom(src => src.GameBorrowed != null));
            CreateMap<Game, GameDetailViewModel>().ForMember(dest => dest.BorrowedFriendName, opt => opt.MapFrom(src => src.GameBorrowed.Friend.Name));
            CreateMap<Friend, FriendViewModel>();
        }
    }
}
