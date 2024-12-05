using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerService.IntegrationTest.Helper
{
    public class HttpClientHelper : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly string BaseAddress;

        public HttpClientHelper(TimeSpan? timeout = null)
        {

            BaseAddress = "http://localhost:6001";

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress),
                Timeout = timeout ?? TimeSpan.FromSeconds(30)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            return await httpClient.GetAsync(endpoint, cancellationToken);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T content, CancellationToken cancellationToken = default)
        {
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(endpoint, jsonContent, cancellationToken);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T content, CancellationToken cancellationToken = default)
        {
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(endpoint, jsonContent, cancellationToken);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            return await httpClient.DeleteAsync(endpoint, cancellationToken);
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}
