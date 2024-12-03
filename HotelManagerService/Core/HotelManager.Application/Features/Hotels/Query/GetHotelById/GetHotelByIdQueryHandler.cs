using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.Hotels.Query.GetHotelById
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQueryRequest, GetHotelByIdQueryResponse>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        public GetHotelByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public async Task<GetHotelByIdQueryResponse> Handle(GetHotelByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var hotel = await unitofWork.GetReadRepostory<Hotel>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.HotelId,
               include: q => q
                .Include(h => h.HotelOfficials)
                .Include(h => h.ContactLocationMappings)
                .ThenInclude(h => h.Location)
                .Include(h => h.HotelContacts));

            mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
            mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());
            var map = mapper.Map<GetHotelByIdQueryResponse, Hotel>(hotel);
  
            if (hotel != null && hotel.ContactLocationMappings != null)
            {
                map.Locations = new List<LocationDto>();
                foreach (var contactLocationMapping in hotel.ContactLocationMappings)
                {
                    map.Locations.Add(
                        new LocationDto()
                        {
                            Name = contactLocationMapping.Location.Name,
                            Latitude = contactLocationMapping.Location.Latitude,
                            Longitude = contactLocationMapping.Location.Longitude
                        });
                }
            }
            return map;
        }
    }
}
