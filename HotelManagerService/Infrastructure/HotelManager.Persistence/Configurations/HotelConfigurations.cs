using Bogus;
using HotelManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManager.Persistence.Configurations
{

    public class HotelConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(150);

            builder.Property(x => x.LocationName)
                .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                 .IsRequired(false)
                 .HasColumnType("timestamp");

            builder.HasIndex(x => x.Name)
                 .HasDatabaseName("IX_Hotel_Name") 
                 .IsUnique(); 

            var currentDate = DateTime.Now;
            Faker faker = new Faker();
            Hotel hotel = new Hotel();
            hotel.Id = 1;
            hotel.Name = "Antalya Suit Otel";
            hotel.Description = "Havuzlu Villalı Suit Her Şey Dahil";
            hotel.LocationName = "İstanbul Merkez Hacı Osman";
            hotel.IsActive = true;
            hotel.IsDeleted = false;
            hotel.AddByUserId = 1;
            hotel.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            Hotel hotel2 = new Hotel();
            hotel2.Id = 2;
            hotel2.Name = "İstanbul Suit Otel";
            hotel2.Description = "Havuzlu Villalı Suit Her Şey Dahil";
            hotel2.LocationName = "İstanbul Merkez Hacı Osman";
            hotel2.IsActive = true;
            hotel2.IsDeleted = false;
            hotel2.AddByUserId = 1;
            hotel2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);
            builder.HasData(hotel, hotel2);
        }
    }
}
