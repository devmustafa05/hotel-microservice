using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs
{
    public class CreteLocationReportPostDto
    {
        public int LocationId { get; set; }
        public ObjectId ReportDocumentId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
