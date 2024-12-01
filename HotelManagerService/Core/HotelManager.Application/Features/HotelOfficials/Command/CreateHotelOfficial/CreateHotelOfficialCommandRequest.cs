using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial
{
    public class CreateHotelOfficialCommandRequest : IRequest<Unit>
    {
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string CorporateTitle { get; set; }
        public required int HotelId { get; set; }
    }
}
