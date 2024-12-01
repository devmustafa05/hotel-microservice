using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts
{
    public class GetAllHotelContactsQueryHandler : IRequestHandler<GetAllHotelContactsQueryRequest, IList<GetAllHotelContactsQueryResponse>>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetAllHotelContactsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<IList<GetAllHotelContactsQueryResponse>> Handle(GetAllHotelContactsQueryRequest request, CancellationToken cancellationToken)
        {
			var hotelContacts = await unitofWork.GetReadRepostory<HotelContact>().GetAllAsync(
			  predicate: x => x.IsActive && !x.IsDeleted);

			var map = mapper.Map<GetAllHotelContactsQueryResponse, HotelContact>(hotelContacts);
			return map;
        }
    }
}
