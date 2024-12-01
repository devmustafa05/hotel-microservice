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
    public class DistrictConfigurations : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(x => x.Name)
            .HasMaxLength(150);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            var currentDate = DateTime.Now;

            District district = new District();
            district.Id = 1;
            district.CityId = 2;
            district.Name = "AdanaDistrict";
            district.IsActive = true;
            district.IsDeleted = false;
            district.AddByUserId = 1;
            district.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

            builder.HasData(district);
        }
    }
}
