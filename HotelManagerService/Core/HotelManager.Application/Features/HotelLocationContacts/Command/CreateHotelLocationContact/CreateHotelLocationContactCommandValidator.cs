using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotelContact
{
    public class CreateHotelLocationContactCommandValidator : AbstractValidator<CreateHotelLocationContactCommandRequest>
    {
        public CreateHotelLocationContactCommandValidator()
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.Latitude)
            .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.Latitude)
           .GreaterThanOrEqualTo(0)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.HotelId)
            .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
