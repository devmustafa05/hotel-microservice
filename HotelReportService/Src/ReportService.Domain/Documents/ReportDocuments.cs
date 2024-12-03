using ReportService.Domain.Common;
using ReportService.Domain.DocumentProperties.ReportDocuments;
using ReportService.Domain.Enums;

namespace ReportService.Domain.Documents
{
    public class ReportDocuments : BaseDocument, IBaseDocument
    {
        public required string Name { get; set; }
        public int HotelCount { get; set; }
        public int PhoneCount { get; set; }
        public ReportDocumentStatuType ReportDocumentStatuType { get; set; }
        public required ReportRequestParameter ReportRequestParameter { get; set; }
        public  ICollection<ReportDocumensHotel>? ReportHotels { get; set; }
        
    }
}
