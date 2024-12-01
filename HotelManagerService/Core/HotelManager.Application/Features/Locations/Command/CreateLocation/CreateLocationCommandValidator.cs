using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.Locations;

namespace HotelManager.Application.Features.Hotels.Command.Locations
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommandRequest>
    {
        public CreateLocationCommandValidator()
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

              RuleFor(x => x.CityId)
               .GreaterThanOrEqualTo(0)
                .NotNull()
                .NotEmpty();

              RuleFor(x => x.DistrictId)
                .GreaterThanOrEqualTo(0)
                .NotNull()
                .NotEmpty();
        }
    }
}
