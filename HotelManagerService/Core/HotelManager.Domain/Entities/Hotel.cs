using HotelManager.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Domain.Entities
{
    [Table("Hotels")]
    public class Hotel : EntityBase, IEntityBase
    {
        public Hotel()
        {
           
        }
        public Hotel(string name, string description, string locationName, decimal latitude, decimal longitude)
        {
            this.Name = name;
            this.Description = description;
            this.Latitude = latitude;
            this.LocationName = locationName;
            this.Longitude = longitude;
            this.Longitude = longitude;
        }
        public string Name { get; set; } 
        public string? Description { get; set; }
        public  string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public  ICollection<HotelOfficial> HotelOfficials { get; set; }
        public ICollection<HotelContact> HotelContacts { get; set; }
        public ICollection<ContactLocationMapping> ContactLocationMappings { get; set; }

        // TODO: Mustafa
        // When transitioning to version 3.0, this section will be activated.
        // public ICollection<HotelLocationContact> HotelLocationContacts { get; set; }
    }
}
