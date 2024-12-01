using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    [Table("Locations")]
    public class Location : EntityBase, IEntityBase
    {
        public string? Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int CityId { get; set; }
        public  City City { get; set; }
        public int DistrictId { get; set; }
        public  District District { get; set; }
        public ICollection<ContactLocationMapping>? LocationHotelLocations { get; set; }
    }
}
