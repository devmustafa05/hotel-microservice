using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetHotelContactById
{
    public class GetHotelLocationContactByIdQueryRequest : IRequest<GetHotelLocationContactByIdQueryResponse>
    {
        public int HotelLocationContacId { get; set; }
    }
}
