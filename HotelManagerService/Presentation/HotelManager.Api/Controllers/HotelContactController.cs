using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts;
using HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelContactController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelContacts()
        {
            var response = await mediator.Send(new GetAllHotelContactsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelContactById(int id)
        {
            var response = await mediator.Send(new GetHotelContactByIdQueryRequest() { HotelContactId = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelContact(CreateHotelContactCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelContact(UpdateHotelContactCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelOfficial(DeleteHotelContactCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
