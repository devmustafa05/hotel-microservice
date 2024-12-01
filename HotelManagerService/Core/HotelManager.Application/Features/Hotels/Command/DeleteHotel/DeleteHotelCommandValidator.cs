using FluentValidation;
using HotelManager.Application.Features.Hotels.Command.DeleteHotel;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommandRequest>
    {
        public DeleteHotelCommandValidator()
        {
            RuleFor(x => x.Id)
             .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
