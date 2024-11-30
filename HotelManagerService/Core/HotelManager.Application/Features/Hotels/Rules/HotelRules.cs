using HotelManager.Application.Bases;
using HotelManager.Application.Features.Hotels.Exceptions;
using HotelManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Rules
{
    public class HotelRules :BaseRules
    {
        public Task HotelTitleMustNotBeSame(IQueryable<Hotel> hotels, string hotelName)
        {
            if (hotels.Any(x => x.Name == hotelName)) throw new HotelNameMustNotBeSameException();
            return Task.CompletedTask;
        }

    }
}
