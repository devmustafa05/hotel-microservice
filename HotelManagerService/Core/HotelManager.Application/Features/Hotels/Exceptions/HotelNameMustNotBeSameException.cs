using HotelManager.Application.Bases;

namespace HotelManager.Application.Features.Hotels.Exceptions
{
    public class HotelNameMustNotBeSameException : BaseExceptions
    {
        public HotelNameMustNotBeSameException() : base("The hotel name you've entered is already in use. Please enter another one.")
        {

        }
    }
    
}
