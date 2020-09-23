using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public interface IFriendDataService
    {
        Task<IEnumerable<FriendViewModel>> GetAllFriends();
        Task<FriendViewModel> GetFriendDetails(Guid friendId);
        Task<bool> AddFriend(FriendViewModel friend);
        Task UpdateFriend(FriendViewModel friend);
        Task DeleteFriend(Guid friendId);
    }
}
