using FluentValidation;
using HotelManager.Application.Features.Hotels.Command.DeleteHotel;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotelContact
{
    public class DeleteHotelContactCommandValidator : AbstractValidator<DeleteHotelCommandRequest>
    {
        public DeleteHotelContactCommandValidator()
        {
            RuleFor(x => x.Id)
             .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
