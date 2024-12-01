using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelContacByIdQueryHandler : IRequestHandler<GetHotelContactByIdQueryRequest, GetHotelContacByIdQueryResponse>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetHotelContacByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<GetHotelContacByIdQueryResponse> Handle(GetHotelContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelContact = await unitofWork.GetReadRepostory<HotelContact>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.HotelContactId);

            var map = mapper.Map<GetHotelContacByIdQueryResponse, HotelContact>(hotelContact);

            if (map == null)
            {
                throw new NotFoundException("Hotel contac not found");
            }

            return map;
        }
    }
}
