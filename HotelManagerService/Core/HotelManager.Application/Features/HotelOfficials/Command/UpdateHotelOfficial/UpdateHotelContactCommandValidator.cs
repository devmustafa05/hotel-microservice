using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
using HotelManager.Application.Features.HotelOfficials.Command.UpdateHotelOfficial;
using HotelManager.Application.Features.Hotels.Command.DeleteHotel;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotelContact
{
    public class UpdateHotelOfficalCommandValidator : AbstractValidator<UpdateHotelOfficalCommandRequest>
    {
        public UpdateHotelOfficalCommandValidator()
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
