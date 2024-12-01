using MediatR;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelContactByIdQueryRequest : IRequest<GetHotelContacByIdQueryResponse>
    {
        public int HotelContactId { get; set; }
    }
}
