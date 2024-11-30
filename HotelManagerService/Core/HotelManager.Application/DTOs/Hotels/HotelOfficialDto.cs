using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.DTOs.Hotels
{
    public record HotelOfficialDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string CorporateTitle { get; set; }
    }
}
