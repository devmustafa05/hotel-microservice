using HotelManager.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Exceptions
{
    public class HotelNameMustNotBeSameException : BaseExceptions
    {
        public HotelNameMustNotBeSameException() : base("The hotel name you've entered is already in use. Please enter another one.")
        {

        }
    }
    
}
