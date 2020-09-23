using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public interface IGameDataService
    {
        Task<IEnumerable<GameViewModel>> GetAllGames();
        Task<GameDetailViewModel> GetGameDetails(Guid gameId);
        Task<bool> AddGame(GameDetailViewModel game);
        Task<bool> LendGame(Guid gameId, Guid friendId);
        Task<bool> TakeGame(Guid gameId);
        Task UpdateGame(GameDetailViewModel game);
        Task DeleteGame(Guid gameId);
    }
}
