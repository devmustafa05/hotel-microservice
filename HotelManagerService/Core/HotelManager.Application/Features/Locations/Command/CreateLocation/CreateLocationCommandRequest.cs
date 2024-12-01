using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.Locations
{
    public class CreateLocationCommandRequest : IRequest<Unit>
    {
        public required string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
