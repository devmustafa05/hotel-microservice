using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public City City { get; set; }
        public District District { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
    }
    public class District
    {
        public string Name { get; set; }
    }
}
