using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotel
{
    public class DeleteHotelCommandRequest :  IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
