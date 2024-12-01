using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotelContact
{
    public class CreateHotelOfficalCommandValidator : AbstractValidator<CreateHotelOfficialCommandRequest>
    {
        public CreateHotelOfficalCommandValidator()
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

            RuleFor(x => x.HotelId)
            .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
