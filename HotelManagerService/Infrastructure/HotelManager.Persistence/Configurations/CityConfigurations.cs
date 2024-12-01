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
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            var currentDate = DateTime.Now;

            City city = new City();
            city.Id = 1;
            city.Name = "Adana";

            city.IsActive = true;
            city.IsDeleted = false;
            city.AddByUserId = 1;
            city.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            City city2 = new City();
            city2.Id = 2;
            city2.Name = "Adıyaman";

            city2.IsActive = true;
            city2.IsDeleted = false;
            city2.AddByUserId = 1;
            city2.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            City city3 = new City();
            city3.Id = 3;
            city3.Name = "Afyonkarahisar";

            city3.IsActive = true;
            city3.IsDeleted = false;
            city3.AddByUserId = 1;
            city3.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            builder.HasData(city, city2, city3);
        }
    }
}
