using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportService.Application.DTOs;
using ReportService.Application.ExternalServices;

namespace ReportService.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationReportController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IExternalApiService externalApiService;

        public LocationReportController(IConfiguration configuration, 
            IExternalApiService externalApiService)
        {
            this.configuration = configuration;
            this.externalApiService = externalApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locationUrl = configuration["HotelMicroServis:Locations"];
            locationUrl = string.IsNullOrWhiteSpace(locationUrl) ? "/locations" : locationUrl;
            var response = await externalApiService.GetDataAsync(locationUrl);
            // var jsonResponse = JsonConvert.DeserializeObject(response);
            var jsonResponse = JsonConvert.DeserializeObject<List<Location>>(response);

            return new JsonResult(jsonResponse);

          
        }

        [HttpPost]
        public async Task<IActionResult> CreteLocationReport(CreteLocationRequestDto request)
        {
            var locationUrl = "/api/Report/GetReport";
            locationUrl = string.IsNullOrWhiteSpace(locationUrl) ? "/api/Report/GetReport" : locationUrl;
            var response = await externalApiService.PostDataAsync<CreteLocationRequestDto>(locationUrl, request);
         
            return Ok(response);
        }

        public async Task<IActionResult> GetLocationReport()
        {
            return Ok();

        }

        public class Location
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public City City { get; set; }
            public District District { get; set; }
        }

        public class City
        {
            public string Name { get; set; }
        }

        public class District
        {
            public string Name { get; set; }
        }
    }
}
