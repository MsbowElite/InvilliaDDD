using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace InvilliaDDD.Server.Services
{
    public class FriendDataService : IFriendDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FriendDataService(HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ?? 
                throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ?? 
                throw new System.ArgumentNullException(nameof(httpContextAccessor));
            SetupToken();
        }


        public async Task<IEnumerable<FriendViewModel>> GetAllFriends()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<FriendViewModel>>
                (await _httpClient.GetStreamAsync($"api/Friends"), new JsonSerializerOptions() 
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<FriendViewModel> GetFriendDetails(Guid friendId)
        {
            return await JsonSerializer.DeserializeAsync<FriendViewModel>
                (await _httpClient.GetStreamAsync($"api/Friends/{friendId}"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> AddFriend(FriendViewModel friend)
        {
            var friendJson =
                new StringContent(JsonSerializer.Serialize(friend), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Friends", friendJson);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateFriend(FriendViewModel friend)
        {
            var friendJson =
                new StringContent(JsonSerializer.Serialize(friend), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/Friends", friendJson);
        }

        public async Task DeleteFriend(Guid friendId)
        {
            await _httpClient.DeleteAsync($"api/Friends/{friendId}");
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
