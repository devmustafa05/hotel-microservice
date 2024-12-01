using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials
{
    public class GetAllHotelOfficialsQueryHandler : IRequestHandler<GetAllHotelOfficialsQueryRequest, IList<GetAllHotelOfficialsQueryResponse>>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetAllHotelOfficialsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<IList<GetAllHotelOfficialsQueryResponse>> Handle(GetAllHotelOfficialsQueryRequest request, CancellationToken cancellationToken)
        {
			var HotelOfficials = await unitofWork.GetReadRepostory<HotelOfficial>().GetAllAsync(
			  predicate: x => x.IsActive && !x.IsDeleted);

			var map = mapper.Map<GetAllHotelOfficialsQueryResponse, HotelOfficial>(HotelOfficials);
			return map;
        }
    }
}
