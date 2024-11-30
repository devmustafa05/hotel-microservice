using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public record HotelOfficialCreationRequest
    {
        public required  string Name { get; set; }
        public required string SurName { get; set; }
        public required string CorporateTitle { get; set; }
    }
}
