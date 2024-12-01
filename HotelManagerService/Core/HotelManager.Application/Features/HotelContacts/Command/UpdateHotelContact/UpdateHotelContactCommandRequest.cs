using HotelManager.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact
{
    public class UpdateHotelContactCommandRequest : IRequest<Unit>
    {  
        public int Id { get; set; }
        public HotelContactType HotelContactType { get; set; }
        public required string Content { get; set; }
        public int HotelId { get; set; }
    }
}
