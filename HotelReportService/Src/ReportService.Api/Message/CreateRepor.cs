namespace ReportService.Api.Message
{
    public class CreateReporMessageCommand
    {
        public int LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
