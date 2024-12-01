using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials
{
    public class GetAllHotelOfficialsQueryResponse
    {
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string CorporateTitle { get; set; }
        public int HotelId { get; set; }
    }
}
