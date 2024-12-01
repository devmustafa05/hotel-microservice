using HotelManager.Application.DTOs.Locations;
using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts;
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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQueryRequest, GetLocationByIdQueryResponse>

    {
		IUnitOfWork unitofWork;
		IMapper mapper;

		public GetLocationByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
		{
			this.unitofWork = unitofWork;
			this.mapper = mapper;
		}
		public async Task<GetLocationByIdQueryResponse> Handle(GetLocationByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var locations = await unitofWork.GetReadRepostory<Location>().GetAsync(
               predicate: x => x.IsActive && !x.IsDeleted && x.Id == request.LocationId);

            mapper.Map<CityDto, City>(new City());
            mapper.Map<DistrictDto, District>(new District());

            var map = mapper.Map<GetLocationByIdQueryResponse, Location>(locations);

            if (map == null)
            {
                throw new NotFoundException("location not found");
            }

            return map;
        }
    }
}
