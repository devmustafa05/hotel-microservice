using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials
{
    public class GetHotelOfficalByIdQueryHandler : IRequestHandler<GetHotelOfficialByIdQueryRequest, GetHotelOfficialByIdQueryResponse>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetHotelOfficalByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<GetHotelOfficialByIdQueryResponse> Handle(GetHotelOfficialByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelOfficial = await unitofWork.GetReadRepostory<HotelOfficial>().GetAsync(
                                          predicate: x => x.IsActive && !x.IsDeleted
                                                       && x.Id == request.HotelOfficialId);

            var map = mapper.Map<GetHotelOfficialByIdQueryResponse, HotelOfficial>(hotelOfficial);


            if (map == null)
            {
                throw new NotFoundException("Hotel offical not found");
            }

            return map;
        }
    }
}
