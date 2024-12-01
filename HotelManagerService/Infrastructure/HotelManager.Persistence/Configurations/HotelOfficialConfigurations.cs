using HotelManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Persistence.Configurations
{
    public class HotelOfficialConfigurations : IEntityTypeConfiguration<HotelOfficial>
    {
        public void Configure(EntityTypeBuilder<HotelOfficial> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(150);

            builder.Property(x => x.SurName)
                .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("IX_Hotel_Official_Name");

            var currentDate = DateTime.Now;

            HotelOfficial hotelOfficial = new HotelOfficial();
            hotelOfficial.Id = 1;
            hotelOfficial.Name = "Mustafa";
            hotelOfficial.SurName = "Yener";
            hotelOfficial.CorporateTitle = "Müdür";
            hotelOfficial.HotelId = 1;

            hotelOfficial.IsActive = true;
            hotelOfficial.IsDeleted = false;
            hotelOfficial.AddByUserId = 1;
            hotelOfficial.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            HotelOfficial hotelOfficial2 = new HotelOfficial();
            hotelOfficial2.Id = 2;
            hotelOfficial2.Name = "Mustafa2";
            hotelOfficial2.SurName = "Yener2";
            hotelOfficial2.CorporateTitle = "Müdür2";
            hotelOfficial2.HotelId = 1;

            hotelOfficial2.IsActive = true;
            hotelOfficial2.IsDeleted = false;
            hotelOfficial2.AddByUserId = 1;
            hotelOfficial2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);
            builder.HasData(hotelOfficial, hotelOfficial2);
        }
    }
}
