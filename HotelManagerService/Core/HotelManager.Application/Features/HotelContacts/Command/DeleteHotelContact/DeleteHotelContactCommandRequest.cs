using MediatR;

namespace HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact
{
    public class DeleteHotelContactCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
