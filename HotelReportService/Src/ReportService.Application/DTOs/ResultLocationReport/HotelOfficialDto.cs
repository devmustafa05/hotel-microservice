using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs.ResultLocationReport
{
    public class HotelOfficialDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? CorporateTitle { get; set; }
    }
}
