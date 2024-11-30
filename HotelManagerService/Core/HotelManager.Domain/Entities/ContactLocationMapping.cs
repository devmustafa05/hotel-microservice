using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    public class ContactLocationMapping : EntityBase, IEntityBase
    {
        public int LocationId { get; set; }
        public  Location Location { get; set; }
        public int HotelLocationContactId { get; set; }
        public  HotelLocationContact HotelLocationContact { get; set; }
        
    }
}
