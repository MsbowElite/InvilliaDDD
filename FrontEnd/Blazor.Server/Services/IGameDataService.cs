using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Shared;
using Blazor.Shared.DTOs;

namespace Blazor.Server.Services
{
    public interface IGameDataService
    {
        Task<PaginatedItemsViewModel<GameDTO>> GetAllGames();
        Task<GameDTO> GetGameDetails(Guid gameId);
        Task<Guid> AddGame(GameDTO game);
        Task DeleteGame(Guid gameId);
    }
}
