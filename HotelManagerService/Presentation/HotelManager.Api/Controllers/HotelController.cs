using HotelManager.Application.Features.Hotels.Command.CreateHotel;
using HotelManager.Application.Features.Hotels.Command.DeleteHotel;
using HotelManager.Application.Features.Hotels.Command.UpdateHotel;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Features.Hotels.Query.GetHotelById;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var response = await mediator.Send(new GetAllHotelsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelById(int id)
        {
            var response = await mediator.Send(new GetHotelByIdQueryRequest() { HotelId = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel(UpdateHotelCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(DeleteHotelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
