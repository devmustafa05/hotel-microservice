using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain.DocumentProperties.ReportDocuments
{
    public class ReportRequestParameter
    {
        public int LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
