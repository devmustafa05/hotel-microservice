using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts
{
    public class GetAllHotelContactsQueryResponse
    {
        public HotelContactType HotelContactType { get; set; }
        public required string Content { get; set; }
    }
}
