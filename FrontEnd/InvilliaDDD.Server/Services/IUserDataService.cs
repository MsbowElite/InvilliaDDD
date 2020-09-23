using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public interface IUserDataService
    {
        Task<IEnumerable<UserAuthViewModel>> GetAllUsers();

        Task<UserAuthViewModel> Login(string username, string password);

        Task<UserViewModel> Register(UserRegisterViewModel user);
    }
}
