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
    public class LocationConfigurations : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Name)
               .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            var currentDate = DateTime.Now;

            Location location = new Location();
            location.Id = 1;
            location.Name = "LocationName";

            location.Latitude = 3542;
            location.Longitude = 5542;

            location.CityId = 1;
            location.DistrictId = 1;

            location.IsActive = true;
            location.IsDeleted = false;
            location.AddByUserId = 1;
            location.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            Location location2 = new Location();
            location2.Id = 2;
            location2.Name = "LocationName2";

            location2.Latitude = 3542;
            location2.Longitude = 5542;

            location2.CityId = 1;
            location2.DistrictId = 1;

            location2.IsActive = true;
            location2.IsDeleted = false;
            location2.AddByUserId = 1;
            location2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            builder.HasData(location, location2);
        }
    }
}
