using FinTransactApp.Models;
using NuGet.Common;
using System.Net.Http.Headers;

namespace FinTransactApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5261/api/"); 
        }

        public async Task<T> CreateAsync<T>(T item, string endPoint, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync(endPoint, item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<List<T>> GetAllAsync<T>(string endPoint, UserToken userToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken.Token);
            var response = await _httpClient.GetAsync(endPoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        public async Task<T> GetAsync<T>(int id, string endPoint, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(endPoint + "/" + $"{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> UpdateAsync<T>(int id, T item, string endPoint, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync(endPoint + "/" + $"{id}", item);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
