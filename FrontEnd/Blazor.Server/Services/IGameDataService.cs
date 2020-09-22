using InvilliaDDD.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Server.Services
{
    public interface IGameDataService
    {
        Task<List<GameViewModel>> GetAllGames();
        Task<GameViewModel> GetGameDetails(Guid gameId);
        Task<bool> AddGame(GameViewModel game);
        Task DeleteGame(Guid gameId);
    }
}
