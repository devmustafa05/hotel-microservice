using MediatR;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotel
{
    public class DeleteHotelCommandRequest :  IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
