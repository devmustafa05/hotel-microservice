using HotelManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Domain.Entities
{
    [Table("HotelOfficials")]
    public class HotelOfficial : EntityBase, IEntityBase
    {
        public HotelOfficial()
        {

        }
        public HotelOfficial(string name, string surName, string corporateTitle, int hotelId)
        {

            this.Name = name;
            this.SurName = surName;
            this.CorporateTitle = corporateTitle;
            this.HotelId = hotelId;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CorporateTitle { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
