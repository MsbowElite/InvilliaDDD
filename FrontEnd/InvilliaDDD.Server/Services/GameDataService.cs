using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Http;

namespace InvilliaDDD.Server.Services
{
    public class GameDataService : IGameDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GameDataService(HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ??
                throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ??
                throw new System.ArgumentNullException(nameof(httpContextAccessor));
            SetupToken();
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGames()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<GameViewModel>>
                (await _httpClient.GetStreamAsync($"api/Games"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<GameDetailViewModel> GetGameDetails(Guid gameId)
        {
            return await JsonSerializer.DeserializeAsync<GameDetailViewModel>
                (await _httpClient.GetStreamAsync($"api/Games/{gameId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> AddGame(GameDetailViewModel game)
        {
            var gameJson =
                new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Games", gameJson);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> LendGame(Guid gameId, Guid friendId)
        {
            var response = await _httpClient.PostAsync($"api/Games/{gameId}/Friends/{friendId}", null);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> TakeGame(Guid gameId)
        {
            var response = await _httpClient.DeleteAsync($"api/Games/{gameId}/Friends");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateGame(GameDetailViewModel game)
        {
            var gameJson =
                new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/Games", gameJson);
        }

        public async Task DeleteGame(Guid gameId)
        {
            await _httpClient.DeleteAsync($"api/Games/{gameId}");
        }

        void SetupToken()
        {
            var accessToken = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Rsa.ToString())?.Value;
            if (accessToken != null)
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
        }
    }
}
