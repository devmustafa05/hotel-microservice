namespace ReportService.Api.Message
{
    public class CreateReporMessageCommand
    {
        public  string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
