using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQueryRequest, IList<GetAllHotelsQueryResponse>>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        public GetAllHotelsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllHotelsQueryResponse>> Handle(GetAllHotelsQueryRequest request, CancellationToken cancellationToken)
        {
            var hotels = await unitofWork.GetReadRepostory<Hotel>().GetAllAsync(
              predicate: x => x.IsActive && !x.IsDeleted,
               include: q => q
                .Include(h => h.HotelOfficials)
                .Include(h => h.ContactLocationMappings)
                .ThenInclude(h => h.Location)
                .Include(h => h.HotelContacts));

             mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
             mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());
           
            var map = mapper.Map<GetAllHotelsQueryResponse, Hotel>(hotels);
            var contactLocationMappings = hotels.SelectMany(s => s.ContactLocationMappings);

            // TODO:auto mapper will be done
            foreach (var mapHotel in map)
            {
                var hotel = hotels.FirstOrDefault(x => x.Id == mapHotel.Id);
                if (hotel != null && hotel.ContactLocationMappings != null)
                {
                    mapHotel.Locations = new List<LocationDto>();
                    foreach (var contactLocationMapping in hotel.ContactLocationMappings)
                    {
                        mapHotel.Locations.Add(
                            new LocationDto()
                            {
                                Name = contactLocationMapping.Location.Name,
                                Latitude = contactLocationMapping.Location.Latitude,
                                Longitude = contactLocationMapping.Location.Longitude
                            });
                    }
                }
            }

            return map;
        }
    }
}
