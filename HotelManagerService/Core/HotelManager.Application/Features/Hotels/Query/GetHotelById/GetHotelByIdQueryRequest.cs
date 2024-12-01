using MediatR;

namespace HotelManager.Application.Features.Hotels.Query.GetHotelById
{
    public class GetHotelByIdQueryRequest : IRequest<GetHotelByIdQueryResponse>
    {
        public int HotelId { get; set; }
    }
}
