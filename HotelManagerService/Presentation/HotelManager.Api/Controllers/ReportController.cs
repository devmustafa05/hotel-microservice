using HotelManager.Application.DTOs;
using HotelManager.Application.Features.LocationReport.CreateReport;
using HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendGrid;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;
        private readonly ISendEndpointProvider sendEndpointProvider;

        public ReportController(IMediator mediator, IConfiguration configuration, ISendEndpointProvider sendEndpointProvider)
        {
            this.mediator = mediator;
            this.configuration = configuration;
            this.sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> GetReport([FromBody] CreteLocationReport req)
        {
            var reportServisQueue = configuration["RabbitMQ:Queues:ReportServis"];
            reportServisQueue = string.IsNullOrWhiteSpace(reportServisQueue) ? "report-servis" : reportServisQueue;

            CreateReportMessageCommandRequest request = new CreateReportMessageCommandRequest()
            {
                QueueName = reportServisQueue,
                LocationId = req.Id,
                Longitude = req.Longitude,
                Latitude = req.Latitude
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> GetReport2()
        {
            string? reportServisQueue = configuration["RabbitMQ:Queues:ReportServis"];
            reportServisQueue = string.IsNullOrWhiteSpace(reportServisQueue) ? "report-servis" : reportServisQueue;

            CreateReportMessageCommandRequest request = new CreateReportMessageCommandRequest()
            {
                QueueName = reportServisQueue,
                LocationId = 1,
                Longitude = 24,
                Latitude = 35
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
