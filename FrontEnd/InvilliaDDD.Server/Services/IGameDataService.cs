using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public interface IGameDataService
    {
        Task<IEnumerable<GameViewModel>> GetAllGames();
        Task<GameViewModel> GetGameById(Guid gameId);
    }
}
