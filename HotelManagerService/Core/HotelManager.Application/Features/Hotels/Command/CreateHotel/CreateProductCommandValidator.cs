using FluentValidation;
using HotelManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommandRequest>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(x => x.Name)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.LocationName)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.Longitude)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

            RuleFor(x => x.Latitude)
           .GreaterThanOrEqualTo(0)
           .NotEmpty();

            RuleFor(x => x.HotelOfficials)
               .ForEach(contact => contact.SetValidator(new HotelOfficialCreationRequestValidator()));

            RuleFor(x => x.HotelContacts)
            .ForEach(contact => contact.SetValidator(new HotelContactCreationRequestValidator()));

            RuleFor(x => x.HotelLocationContacts)
           .ForEach(contact => contact.SetValidator(new HotelLocationContactCreationRequestValidator()));



            // RuleFor(x => x.HotelOfficials.)
            //.GreaterThanOrEqualTo(0)
            //.NotEmpty();

        }
        
    }
}
