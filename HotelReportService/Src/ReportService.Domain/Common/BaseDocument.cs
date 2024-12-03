using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain.Common
{
    public class BaseDocument : IBaseDocument
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
