using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Server.Services
{
    public class IdentityDataService : IIdentityDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityDataService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ??
                throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ??
                throw new System.ArgumentNullException(nameof(httpContextAccessor));
            SetupToken();
        }

        public async Task<UserAuthViewModel> Login(string username, string password)
        {
            var user = new UserViewModel { Username = username, Password = password };

            var serializedUser = JsonConvert.SerializeObject(user);

            var response = await _httpClient.PostAsync($"api/Users/Login", new StringContent(serializedUser, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<UserAuthViewModel>(json));
            }

            throw new Exception(message: "Server Error!");
        }

        public async Task<UserViewModel> Register(UserRegisterViewModel userRegister)
        {
            var serializedUser = JsonConvert.SerializeObject(userRegister);

            var response = await _httpClient.PostAsync($"api/Users/Register", new StringContent(serializedUser, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<UserViewModel>(json));
            }

            throw new Exception(message: "Server Error!");
        }

        private void HandleResponseCode(int code)
        {
            switch (code)
            {
                case 200:
                case 201:
                    return;
                case 409:
                    throw new Exception(message: "Username duplicated!");
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
