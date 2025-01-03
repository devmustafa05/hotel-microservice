﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs.ResultLocationReport
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<HotelOfficialDto> HotelOfficials { get; set; }
        public List<HotelContactsDto> HotelContacts { get; set; }
        public List<HotelLocationContactDto> Locations { get; set; }
    }
}
