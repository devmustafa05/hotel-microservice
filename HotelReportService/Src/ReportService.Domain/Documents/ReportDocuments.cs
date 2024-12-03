using ReportService.Domain.Common;
using ReportService.Domain.Enums;

namespace ReportService.Domain.Documents
{
    public class ReportDocuments : BaseDocument, IBaseDocument
    {
        public required string Name { get; set; }
        public ReportDocumentStatuType ReportDocumentStatuType { get; set; }
        public required ReportRequestParameters ReportRequestParameters { get; set; }
    }
}
