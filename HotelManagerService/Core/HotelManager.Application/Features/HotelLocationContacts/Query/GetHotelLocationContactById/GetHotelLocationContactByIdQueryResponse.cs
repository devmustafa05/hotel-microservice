using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelLocationContactByIdQueryResponse
    {
        public required string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
