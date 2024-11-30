using HotelManager.Application.DTOs.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class CreateHotelCommandRequest : IRequest<Unit>
    {
        public required string Name { get; set; }
        public required string LocationName { get; set; }
        public required string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<HotelOfficialCreationRequest>? HotelOfficials { get; set; }
        public List<HotelContactCreationRequest>? HotelContacts { get; set; }
        public List<HotelLocationContactCreationRequest>? HotelLocationContacts { get; set; }

    }
}
