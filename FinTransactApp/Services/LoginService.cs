using FinTransactApp.Models;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;

namespace FinTransactApp.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5261/api/");
        }
            
        public async Task<UserToken> LoginAsync<T>(T item)
        {
            var response = await _httpClient.PostAsJsonAsync("UserAuthentication/login", item);

            response.EnsureSuccessStatusCode(); 

            var result = await response.Content.ReadFromJsonAsync<UserToken>();

            return result; 
        }

    }
}
