using AutoMapper;
using InvilliaDDD.Identity.API.Models;

namespace InvilliaDDD.Identity.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, Entities.User>(MemberList.Source);
            CreateMap<Entities.User, UserModel>().ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<Entities.User, UserAuthModel>(MemberList.Source);
            CreateMap<Entities.UserRoles, UserRole>(MemberList.Source);
        }
    }
}
