using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotelContact
{
    public class DeleteHotelLocationContactCommandValidator : AbstractValidator<DeleteHotelContactCommandRequest>
    {
        public DeleteHotelLocationContactCommandValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(0)
             .NotNull()
             .NotEmpty();
        }
    }
}
