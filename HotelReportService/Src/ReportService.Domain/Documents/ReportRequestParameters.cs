using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReportService.Domain.Documents
{
    public class ReportRequestParameters 
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
