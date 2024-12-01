using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Query.GetAllHotelOfficials
{
    public class GetAllHotelOfficialsQueryRequest : IRequest<IList<GetAllHotelOfficialsQueryResponse>>
    {

    }
}
