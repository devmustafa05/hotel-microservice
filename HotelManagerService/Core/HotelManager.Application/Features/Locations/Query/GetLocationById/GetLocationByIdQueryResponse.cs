using HotelManager.Application.DTOs.Locations;
using HotelManager.Domain.Enums;
using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetLocationByIdQueryResponse
    {
        public required string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public required CityDto City { get; set; }
        public required DistrictDto District { get; set; }

    }
}
