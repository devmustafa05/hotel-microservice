using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReportService.Domain.Common
{
    public interface IBaseDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int AddByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public string CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
