using MediatR;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class CreateHotelCommandRequest : IRequest<Unit>
    {
        public required string Name { get; set; }
        public required string LocationName { get; set; }
        public required string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<HotelOfficialCreationRequest>? HotelOfficials { get; set; }
        public List<HotelContactCreationRequest>? HotelContacts { get; set; }
        public List<int>? LocationIds { get; set; }

        

    }
}
