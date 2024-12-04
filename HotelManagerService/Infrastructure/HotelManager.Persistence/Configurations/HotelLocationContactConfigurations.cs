using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Persistence.Configurations
{
    public class HotelLocationContactConfigurations : IEntityTypeConfiguration<HotelLocationContact>
    {
        public void Configure(EntityTypeBuilder<HotelLocationContact> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("IX_Hotel_Location_Contact_Name")
                .IsUnique();

            var currentDate = DateTime.Now;

            HotelLocationContact hotelLocationContact = new HotelLocationContact();
            hotelLocationContact.Id = 1;
            hotelLocationContact.Latitude = 35;
            hotelLocationContact.Longitude = 45;
            hotelLocationContact.HotelId = 1;

            hotelLocationContact.IsActive = true;
            hotelLocationContact.IsDeleted = false;
            hotelLocationContact.AddByUserId = 1;
            hotelLocationContact.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);


            HotelLocationContact hotelLocationContact2 = new HotelLocationContact();
            hotelLocationContact2.Id = 2;
            hotelLocationContact2.Latitude = 36;
            hotelLocationContact2.Longitude = 48;
            hotelLocationContact2.HotelId = 1;

            hotelLocationContact2.IsActive = true;
            hotelLocationContact2.IsDeleted = false;
            hotelLocationContact2.AddByUserId = 1;
            hotelLocationContact2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

           // builder.HasData(hotelLocationContact, hotelLocationContact2);
        }
    }
}
