using FluentValidation;
using HotelManager.Application.Features.HotelOfficials.Command.DeleteHotelOfficial;
using HotelManager.Application.Features.Hotels.Command.DeleteHotel;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotelContact
{
    public class DeleteHotelOfficalCommandValidator : AbstractValidator<DeleteHotelOfficialCommandRequest>
    {
        public DeleteHotelOfficalCommandValidator()
        {
            RuleFor(x => x.Id)
             .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
