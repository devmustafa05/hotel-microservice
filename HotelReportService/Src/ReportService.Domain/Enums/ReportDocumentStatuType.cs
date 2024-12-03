using System.ComponentModel;

namespace ReportService.Domain.Enums
{
    public enum ReportDocumentStatuType
    {
        [Description("")]
        Null = 0,
        [Description("Sent")]
        Sent = 1,
        [Description("Reporting")]
        Reporting = 2,
        [Description("Report Ready")]
        ReportReady = 3
    }
}
