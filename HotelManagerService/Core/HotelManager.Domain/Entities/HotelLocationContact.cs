using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    
    [Table("HotelLocationContacts")]
    public class HotelLocationContact : EntityBase,IEntityBase
    {
        public string? Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<ContactLocationMapping>? LocationHotelLocations { get; set; }
    }
}
