using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Blazor.Server.Services
{
    public class GameDataService : IGameDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GameDataService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ??
                throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ??
                throw new System.ArgumentNullException(nameof(httpContextAccessor));
            SetupToken();
        }

        public async Task<List<GameViewModel>> GetAllGames()
        {
            var responseMessage = await _httpClient.GetAsync($"api/Games");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<List<GameViewModel>>(json));
        }

        public async Task<GameViewModel> GetGameDetails(Guid gameId)
        {
            var responseMessage = await _httpClient.GetAsync($"api/Games/{gameId}");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<GameViewModel>(json));
        }

        public async Task<bool> AddGame(GameViewModel game)
        {

            var serializedGame = JsonConvert.SerializeObject(game);

            var response = await _httpClient.PostAsync($"api/Games", new StringContent(serializedGame, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteGame(Guid gameId)
        {
            await _httpClient.DeleteAsync($"api/Games/{gameId}");
        }

        private void HandleResponseCode(int code)
        {
            switch (code)
            {
                case 200:
                case 201:
                    return;
                case 409:
                    throw new Exception(message: "Game duplicated!");
                default:
                    throw new Exception(message: "Server Error!");
            }
        }

        private void SetupToken()
        {
            var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync("access_token").Result;
            if (accessToken != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            }
        }

    }
}
