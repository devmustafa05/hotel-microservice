using FluentValidation;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class HotelContactCreationRequestValidator : AbstractValidator<HotelContactCreationRequest>
    {
        public HotelContactCreationRequestValidator()
        {
            RuleFor(x => x.HotelContactType)
                .Must(contactType => contactType != HotelContactType.Null && contactType <= HotelContactType.EmailAddress)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Content)
                  .Matches(@"^90\d{10}$") 
                  .WithMessage("The phone number must be in a valid format. Example: 90xxxxxxxxxx")
                  .When(x => x.HotelContactType == HotelContactType.PhoneNumber);

            RuleFor(x => x.Content)
               .EmailAddress()
               .WithMessage("The email address must be in a valid format.")
               .When(x => x.HotelContactType == HotelContactType.EmailAddress); 
        }
    }
}
