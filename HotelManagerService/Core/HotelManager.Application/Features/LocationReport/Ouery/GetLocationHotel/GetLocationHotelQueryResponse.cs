using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel
{
    public class GetLocationHotelQueryResponse
    {
        public int HotelCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
