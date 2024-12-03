using HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.LocationReport.CreateReport
{
    public class CreateReportMessageCommandRequest : IRequest<CreateReportMessageCommandResponse>
    {
        public required string QueueName { get; set; }
        public int LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
