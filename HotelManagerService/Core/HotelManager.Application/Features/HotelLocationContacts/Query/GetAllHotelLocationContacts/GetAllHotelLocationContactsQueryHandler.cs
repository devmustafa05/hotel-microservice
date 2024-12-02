using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials;
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

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts
{
    public class GetAllHotelLocationContactsQueryHandler : IRequestHandler<GetAllHotelLocationContactsQueryRequest, IList<GetAllHotelLocationContactsQueryResponse>>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetAllHotelLocationContactsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<IList<GetAllHotelLocationContactsQueryResponse>> Handle(GetAllHotelLocationContactsQueryRequest request, CancellationToken cancellationToken)
        {
			var hotelLocationContacts = await unitofWork.GetReadRepostory<HotelLocationContact>().GetAllAsync(
			  predicate: x => x.IsActive && !x.IsDeleted);

			var map = mapper.Map<GetAllHotelLocationContactsQueryResponse, HotelLocationContact>(hotelLocationContacts);
			return map;
        }
    }
}
