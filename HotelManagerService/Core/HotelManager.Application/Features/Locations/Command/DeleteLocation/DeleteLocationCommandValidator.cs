using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.Locations;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;

namespace HotelManager.Application.Features.Hotels.Command.Locations
{
    public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationContactRequest>
    {
        public DeleteLocationCommandValidator()
        {
            RuleFor(x => x.Id)
           .GreaterThanOrEqualTo(0)
           .NotNull()
           .NotEmpty();
        }
    }
}
