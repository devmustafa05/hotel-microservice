using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.Locations;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
using HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Command.DeleteHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Command.UpdateHotelOfficial;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials;
using HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator mediator;

        public LocationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocationContacts()
        {
            var response = await mediator.Send(new GetAllLocationsQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var response = await mediator.Send(new GetLocationByIdQueryRequest() { LocationId = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocationContact(CreateLocationCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocationContact(UpdateLocationCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocationOfficial(DeleteLocationContactRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
