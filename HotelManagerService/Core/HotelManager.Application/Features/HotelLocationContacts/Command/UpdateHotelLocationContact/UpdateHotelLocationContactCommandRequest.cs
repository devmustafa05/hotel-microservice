using HotelManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact
{
    public class UpdateHotelLocationContactCommandRequest : IRequest<Unit>
    {
        public int HotelId { get; set; }
        public List<int>? LocationIds { get; set; }
    }
}
