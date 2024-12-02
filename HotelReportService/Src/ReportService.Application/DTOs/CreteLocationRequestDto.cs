using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs
{
    public class CreteLocationRequestDto
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal longitude { get; set; }

    }
}
