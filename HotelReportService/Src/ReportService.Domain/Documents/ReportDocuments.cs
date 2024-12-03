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
