using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.DTOs.Messaging
{
    public class CreateReporMessageCommandDto
    {
        public int LocationId { get; set; }
        public required string ReportDocumentId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
