using HotelManager.Application.DTOs.Hotels;
using HotelManager.Domain.Entities;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public record GetAllHotelsQueryResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public IList<HotelOfficialDto>?  HotelOfficials { get; set; }
        public IList<HotelContactsDto>? HotelContacts { get; set; }
        public IList<LocationDto>? Locations { get; set; }
    }

    public class LocationDto
    {
        public string? Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
