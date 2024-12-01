using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelContacByIdQueryResponse
    {
        public HotelContactType HotelContactType { get; set; }
        public required string Content { get; set; }
    }
}
