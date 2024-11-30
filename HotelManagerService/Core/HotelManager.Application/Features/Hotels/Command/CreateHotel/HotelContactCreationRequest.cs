using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class HotelContactCreationRequest
    {
        public HotelContactType HotelContactType { get; set; }
        public required string Content { get; set; }
    }
}
