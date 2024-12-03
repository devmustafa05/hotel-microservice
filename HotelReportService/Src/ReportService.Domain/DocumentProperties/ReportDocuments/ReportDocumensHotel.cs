using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain.DocumentProperties.ReportDocuments
{
    public class ReportDocumensHotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public required string? LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<ReportDocumensHotelOfficial>? HotelOfficials { get; set; }
        public List<ReportDocumensHotelContact>? HotelContacts { get; set; }
        public List<ReportDocumensHotelLocationContact>? HotelLocationContacts { get; set; }
    }
}
