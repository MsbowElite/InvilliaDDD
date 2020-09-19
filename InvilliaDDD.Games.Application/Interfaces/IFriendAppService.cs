using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using InvilliaDDD.GameManager.Application.ViewModels;

namespace InvilliaDDD.GameManager.Application.Interfaces
{
    public interface IFriendAppService : IDisposable
    {
        Task<IEnumerable<FriendViewModel>> GetAll();
        Task<FriendViewModel> GetById(Guid id);

        Task<ValidationResult> Register(FriendViewModel friendViewModel);
        Task<ValidationResult> Update(FriendViewModel friendViewModel);
        Task<ValidationResult> Delete(Guid id);
    }
}
