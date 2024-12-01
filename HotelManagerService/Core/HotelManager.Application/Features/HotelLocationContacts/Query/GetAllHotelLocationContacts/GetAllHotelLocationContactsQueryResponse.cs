using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelLocationContacts
{
    public class GetAllHotelLocationContactsQueryResponse
    {
        public required string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
