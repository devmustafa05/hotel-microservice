using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReportService.Application.DTOs;
using ReportService.Application.ExternalServices;

namespace ReportService.Application.Services.ReportService
{
    public class LocationService : ILocationService
    {
        private readonly IExternalApiService externalApiService;
        private readonly IConfiguration configuration;

        public LocationService(IExternalApiService externalApiService, IConfiguration configuration)
        {
            this.externalApiService = externalApiService;
            this.configuration = configuration;
        }
        public async Task<List<LocationDto>> GetLocation()
        {
            var locationUrl = configuration["HotelMicroService:Locations"];
            locationUrl = string.IsNullOrWhiteSpace(locationUrl) ? "/api/report/getreport" : locationUrl;
            var response = await externalApiService.GetDataAsync(locationUrl);
            var jsonResponse = JsonConvert.DeserializeObject<List<LocationDto>>(response);
            return jsonResponse;
        }
    }
}
