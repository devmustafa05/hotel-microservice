using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ReportService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
