using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    [Table("Citys")]
    public class City : EntityBase, IEntityBase
    {
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
    
}
