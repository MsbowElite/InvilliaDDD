using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Shared;
using Blazor.Shared.DTOs;
using Newtonsoft.Json;

namespace Blazor.Server.Services
{
    public class GameDataService: IGameDataService
    {
        private readonly HttpClient _httpClient;

        public GameDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GameDTO>> GetAllGames()
        {
            var responseMessage = await _httpClient.GetAsync($"api/Games");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<List<GameDTO>>(json));
        }

        public async Task<GameDTO> GetGameDetails(Guid gameId)
        {
            var responseMessage = await _httpClient.GetAsync($"api/Games/{gameId}");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<GameDTO>(json));
        }

        public async Task<Guid> AddGame(GameDTO game)
        {

            var serializedGame = JsonConvert.SerializeObject(game);

            var response = await _httpClient.PostAsync($"api/Games", new StringContent(serializedGame, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<Guid>(json));
            }

            return Guid.Empty;
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
    }
}
