namespace HotelManager.Application.DTOs
{
    public class CreteLocationReport
    {
        public int LocationId { get; set; }
        public required string ReportDocumentId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
