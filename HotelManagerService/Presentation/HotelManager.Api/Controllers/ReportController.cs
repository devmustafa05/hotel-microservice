using HotelManager.Application.DTOs;
using HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult GetReport([FromBody] CreteLocationReport req)
        {
            GetLocationHotelQueryRequest request = new GetLocationHotelQueryRequest();

            request.Id = req.Id;
            request.Longitude = req.Longitude;
            request.Latitude = req.Latitude;

            var response = mediator.Send(request);
            return Ok(response);
        }
    }
}
