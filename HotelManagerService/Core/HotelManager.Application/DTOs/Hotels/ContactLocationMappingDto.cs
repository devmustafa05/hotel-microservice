using HotelManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.DTOs.Hotels
{
    public class ContactLocationMappingDto
    {
        public int LocationId { get; set; }
        public int HotelId { get; set; }
    }
}
