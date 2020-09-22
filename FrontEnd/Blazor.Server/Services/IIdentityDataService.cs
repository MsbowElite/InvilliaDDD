using InvilliaDDD.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Server.Services
{
    public interface IIdentityDataService
    {
        Task<UserAuthViewModel> Login(string username, string password);
        Task<UserViewModel> Register(UserRegisterViewModel userRegister);
    }
}
