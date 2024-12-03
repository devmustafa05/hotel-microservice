using Microsoft.AspNetCore.Mvc;
using ReportService.Application.DTOs;
using ReportService.Application.ExternalServices;
using ReportService.Application.Services.ReportService;

namespace ReportService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocationReportController : ControllerBase
    {
        private readonly IReportService reportService;
        private readonly ILocationService locationService;
        public LocationReportController(IReportService reportService,
            ILocationService locationService,
            IExternalApiService externalApiService)
        {
            this.reportService = reportService;
            this.locationService = locationService;
        }   

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var response = await locationService.GetLocation();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreteLocationReport(CreteLocationRequestDto request)
        {
            var response = await reportService.CreteLocationReport(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ResultLocationReport(ResultLocationReportDto request)
        {
            //var locationUrl = "/api/Report/GetReport";
            //locationUrl = string.IsNullOrWhiteSpace(locationUrl) ? "/api/Report/GetReport" : locationUrl;
            //var response = await externalApiService.PostDataAsync<CreteLocationRequestDto>(locationUrl, request);

            var ssTest = request;
            return Ok();
        }
        public class ResultLocationReportDto
        {
            public int HotelCount { get; set; }
            public int PhoneCount { get; set; }
        }
    }
}
