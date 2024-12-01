using HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Command.DeleteHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Command.UpdateHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelOfficialController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelOfficialController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllHotelOfficials()
        {
            var response = await mediator.Send(new GetAllHotelOfficialsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelOfficialById(int id)
        {
            var response = await mediator.Send(new GetHotelOfficialByIdQueryRequest() { HotelOfficialId = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelOfficial(CreateHotelOfficialCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelOfficial(UpdateHotelOfficalCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelOfficial(DeleteHotelOfficialCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
