using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Features.Hotels.Query.GetHotelById;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelLocationContactByIdQueryHandler : IRequestHandler<GetHotelLocationContactByIdQueryRequest, GetHotelLocationContactByIdQueryResponse>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetHotelLocationContactByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<GetHotelLocationContactByIdQueryResponse> Handle(GetHotelLocationContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelLocationContact = await unitofWork.GetReadRepostory<HotelLocationContact>().GetAsync(
                                                    predicate: x => x.IsActive && !x.IsDeleted);

            if (hotelLocationContact == null)
            {
                throw new NotFoundException("Hotel location contact contac not found");
            }

            var map = mapper.Map<GetHotelLocationContactByIdQueryResponse, HotelLocationContact>(hotelLocationContact);
            return map;
        }
    }
}
