using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact
{
    public class DeleteLocationContactRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
