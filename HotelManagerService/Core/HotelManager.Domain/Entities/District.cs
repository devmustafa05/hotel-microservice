using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    [Table("Districts")]
    public class District: EntityBase, IEntityBase
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public  City City { get; set; }
    }
}
