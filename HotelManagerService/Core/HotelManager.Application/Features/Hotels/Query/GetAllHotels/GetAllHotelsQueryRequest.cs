using MediatR;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public class GetAllHotelsQueryRequest : IRequest<IList<GetAllHotelsQueryResponse>>
    {
    }
}
