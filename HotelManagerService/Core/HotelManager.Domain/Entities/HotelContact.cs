using HotelManager.Domain.Common;
using HotelManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    [Table("HotelContacts")]
    public class HotelContact : EntityBase, IEntityBase
    {
        public HotelContact()
        {
                
        }
        public HotelContact(string content, HotelContactType hotelContactType, int hotelId)
        {  
            this.Content = content;
            this.HotelContactType = hotelContactType;
            this.HotelId = hotelId;
        }
        public HotelContactType HotelContactType { get; set; }
        public string Content { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
