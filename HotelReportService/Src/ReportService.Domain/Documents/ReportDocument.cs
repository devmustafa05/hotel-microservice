using ReportService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.CompilerServices;
using MongoDB.Bson.Serialization;

namespace ReportService.Domain.Documents
{  
    public class ReportDocuments : BaseDocument, IBaseDocument
    {
        public required string LocationContactName { get; set; }
        public required string LocationContactPhone { get; set; }
        public required string LocationContactEmail { get; set; }
    }
}
