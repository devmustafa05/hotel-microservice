using ReportService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain.DocumentProperties.ReportDocuments
{
    public class ReportDocumensHotelContact
    {
        public int Id { get; set; }
        public HotelContactType HotelContactType { get; set; }
        public string? Content { get; set; }
    }
}
