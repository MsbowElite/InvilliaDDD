using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using InvilliaDDD.Core.ViewModels;

namespace InvilliaDDD.Server.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;

        public UserDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserAuthViewModel>> GetAllUsers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<UserAuthViewModel>>
                (await _httpClient.GetStreamAsync($"api/Users"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<UserAuthViewModel> Login(string username, string password)
        {
            var user = new UserViewModel
            {
                Username = username,
                Password = password
            };

            var userJson =
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Users/Login", userJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<UserAuthViewModel>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<UserViewModel> Register(UserRegisterViewModel user)
        {
            var userJson =
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Users/Register", userJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<UserViewModel>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }
    }
}
