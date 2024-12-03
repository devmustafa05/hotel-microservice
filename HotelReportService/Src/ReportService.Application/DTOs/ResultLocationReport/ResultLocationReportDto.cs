using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs.ResultLocationReport
{
    public class ResultLocationReportDto
    {
        public int HotelCount { get; set; }
        public int PhoneCount { get; set; }
        public string ReportDocumentId { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
