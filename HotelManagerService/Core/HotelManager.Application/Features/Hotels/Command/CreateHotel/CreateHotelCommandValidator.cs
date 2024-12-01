using FluentValidation;
using HotelManager.Application.Features.Hotels.Command.UpdateHotel;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class CreateHotelCommandValidator : AbstractValidator<UpdateHotelCommandRequest>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.LocationName)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.Longitude)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

            RuleFor(x => x.Latitude)
           .GreaterThanOrEqualTo(0)
           .NotEmpty();
        }
    }
}
