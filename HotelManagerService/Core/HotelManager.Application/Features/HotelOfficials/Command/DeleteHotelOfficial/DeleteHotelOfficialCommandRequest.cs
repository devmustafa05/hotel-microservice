using HotelManager.Application.Interfaces.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Command.DeleteHotelOfficial
{
    public class DeleteHotelOfficialCommandRequest : IRequest<Unit>
    {
       

        public int Id { get; set; }
    }
}
