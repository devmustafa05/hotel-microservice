using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.Locations;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;

namespace HotelManager.Application.Features.Hotels.Command.Locations
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommandRequest>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(x => x.Id)
           .GreaterThanOrEqualTo(0)
           .NotNull()
           .NotEmpty();

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
