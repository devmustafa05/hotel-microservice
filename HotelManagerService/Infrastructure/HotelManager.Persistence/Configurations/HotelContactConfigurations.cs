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
    public class HotelContactConfigurations : IEntityTypeConfiguration<HotelContact>
    {
        public void Configure(EntityTypeBuilder<HotelContact> builder)
        {
            builder.Property(x => x.Content)
            .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            builder.HasIndex(x => x.Content)
            .HasDatabaseName("IX_Hotel_Contact_Content")
            .IsUnique();

            var currentDate = DateTime.Now;

            HotelContact hotelContact = new HotelContact();
                
            hotelContact.Id = 1;
            hotelContact.Content = "905412045792";
            hotelContact.HotelContactType = HotelContactType.PhoneNumber;

            hotelContact.HotelId = 1;
            hotelContact.IsActive = true;
            hotelContact.IsDeleted = false;
            hotelContact.AddByUserId = 1;
            hotelContact.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);


            HotelContact hotelContact2 = new HotelContact();
            hotelContact2.Id = 2;
            hotelContact2.Content = "mustafa_yener05@hotmail.com";
            hotelContact2.HotelContactType = HotelContactType.EmailAddress;
            hotelContact2.HotelId = 2;

            hotelContact2.IsActive = true;
            hotelContact2.IsDeleted = false;
            hotelContact2.AddByUserId = 1;
            hotelContact2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);
            
            builder.HasData(hotelContact, hotelContact2);
        }
    }
}
