using HotelManager.Domain.Enums;
using MediatR;

namespace HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact
{
    public class CreateHotelContactCommandRequest : IRequest<Unit>
    {
        public HotelContactType HotelContactType { get; set; }
        public required string Content { get; set; }
        public int HotelId { get; set; }
    }
}
