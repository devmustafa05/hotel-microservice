using FluentValidation;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class HotelOfficialCreationRequestValidator : AbstractValidator<HotelOfficialCreationRequest>
    {
        public HotelOfficialCreationRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.SurName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CorporateTitle)
               .NotNull()
               .NotEmpty();
        }
    }
}
