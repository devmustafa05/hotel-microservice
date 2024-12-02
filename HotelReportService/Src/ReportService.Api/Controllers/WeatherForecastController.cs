using Microsoft.AspNetCore.Mvc;
using ReportService.Application.Services.ReportService;

namespace ReportService.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class testDenemeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<testDenemeController> _logger;

        private readonly IReportService reportService;

        public testDenemeController(ILogger<testDenemeController> logger, IReportService reportService)
        {
            _logger = logger;
            this.reportService = reportService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


      
        public async Task<string>  Test()
        {

             await reportService.GetReportTest();

            return "Mustafa Yener"; 
        }

        public async Task<string> Test2()
        {

            await reportService.GetReportTest2();

            return "Mustafa Yener";
        }
    }
}
