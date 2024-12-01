using MediatR;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts
{
    public class GetAllHotelContactsQueryRequest : IRequest<IList<GetAllHotelContactsQueryResponse>>
    {

    }
}
