using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public class GetAllHotelsQueryRequest : IRequest<IList<GetAllHotelsQueryResponse>>
    {
    }
}
