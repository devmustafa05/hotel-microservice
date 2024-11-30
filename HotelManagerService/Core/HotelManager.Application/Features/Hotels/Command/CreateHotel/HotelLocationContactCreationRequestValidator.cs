using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class HotelLocationContactCreationRequestValidator : AbstractValidator<HotelLocationContactCreationRequest>
    {
        public HotelLocationContactCreationRequestValidator()
        {
            RuleFor(x => x.Name)
                 .NotNull()
                 .NotEmpty();

            RuleFor(x => x.Latitude)
                .GreaterThanOrEqualTo(0)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Longitude)
               .GreaterThanOrEqualTo(0)
               .NotNull()
               .NotEmpty();
        }
    }
}
