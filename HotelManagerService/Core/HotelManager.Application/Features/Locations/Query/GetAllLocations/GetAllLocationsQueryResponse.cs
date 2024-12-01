using HotelManager.Application.DTOs.Locations;
using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts
{
    public class GetAllLocationsQueryResponse
    {
        public required string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public required CityDto City { get; set; }
        public required DistrictDto District { get; set; }
    }
}
