using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.ExternalServices
{
    public class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient httpClient;
        public ExternalApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string> GetDataAsync(string endpoint)
        {
            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> PostDataAsync<T>(string endpoint, T payload)
        {
            try
            {
                var serializedPayload = JsonConvert.SerializeObject(payload);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint)
                {
                    Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                if(response.StatusCode == HttpStatusCode.OK && response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();


                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {   
                return false;
            }
        }
    }
}
