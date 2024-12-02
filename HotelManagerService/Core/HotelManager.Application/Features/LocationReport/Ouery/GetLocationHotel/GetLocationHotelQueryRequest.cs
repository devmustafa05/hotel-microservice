using HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelContacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel
{
    public class GetLocationHotelQueryRequest : IRequest<GetLocationHotelQueryResponse>
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
