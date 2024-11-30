using HotelManager.Application.DTOs.Hotels;
using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public record GetAllHotelsQueryResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public IList<HotelOfficialDto>?  HotelOfficials { get; set; }
        public IList<HotelContactsDto>? HotelContacts { get; set; }
        public IList<HotelLocationContactDto>? HotelLocationContacts { get; set; }
    }
}
