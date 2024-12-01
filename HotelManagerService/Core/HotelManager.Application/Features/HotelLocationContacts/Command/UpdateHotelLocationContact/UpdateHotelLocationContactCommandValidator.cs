﻿using FluentValidation;
using HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact;
using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
using HotelManager.Domain.Enums;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotelContact
{
    public class UpdateHotelLocationContactCommandValidator : AbstractValidator<UpdateHotelLocationContactCommandRequest>
    {
        public UpdateHotelLocationContactCommandValidator()
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
        }
    }
}