using FluentValidation;
using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
