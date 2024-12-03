using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts;
using HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelLocationContactController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelLocationContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelLocationContactContacts()
        {
            var response = await mediator.Send(new GetAllHotelLocationContactsQueryRequest());
            return Ok(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetLocationContactById(int id)
        //{
        //    var response = await mediator.Send(new GetHotelLocationContactByIdQueryRequest() { HotelLocationContacId = id });
        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateHotelLocationContact(CreateHotelLocationContactCommandRequest request)
        //{
        //    var response = await mediator.Send(request);
        //    return Ok(response);
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateHotelLocationContactContact(UpdateHotelLocationContactCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelLocationContactOfficial(DeleteHotelLocationContactCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
