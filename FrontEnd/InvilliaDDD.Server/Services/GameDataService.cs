using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public class GameDataService : IGameDataService
    {
        private readonly HttpClient _httpClient;

        public GameDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGames()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<GameViewModel>>
                (await _httpClient.GetStreamAsync($"api/Games"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<GameViewModel> GetGameById(Guid gameId)
        {
            return await JsonSerializer.DeserializeAsync<GameViewModel>
                (await _httpClient.GetStreamAsync($"api/country{gameId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
