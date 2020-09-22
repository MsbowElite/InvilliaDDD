using AutoMapper;
using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.Identity.API.Models;

namespace InvilliaDDD.Identity.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, Entities.User>(MemberList.Source);
            CreateMap<Entities.User, UserModel>().ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<Entities.User, UserAuthViewModel>(MemberList.Source);
            CreateMap<Entities.UserRoles, UserRoleViewModel>(MemberList.Source);
        }
    }
}
