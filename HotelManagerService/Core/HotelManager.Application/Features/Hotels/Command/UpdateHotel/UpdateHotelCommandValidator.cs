using FluentValidation;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class UpdateHotelCommandValidator : AbstractValidator<CreateHotelCommandRequest>
    {
        public UpdateHotelCommandValidator()
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

            RuleFor(x => x.HotelOfficials)
               .ForEach(contact => contact.SetValidator(new HotelOfficialCreationRequestValidator()));

            RuleFor(x => x.HotelContacts)
                .ForEach(contact => contact.SetValidator(new HotelContactCreationRequestValidator()));
        }
    }
}
