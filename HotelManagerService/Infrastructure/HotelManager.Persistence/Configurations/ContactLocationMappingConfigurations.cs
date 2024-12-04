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
    public class ContactLocationMappingConfigurations : IEntityTypeConfiguration<ContactLocationMapping>
    {
        public void Configure(EntityTypeBuilder<ContactLocationMapping> builder)
        {
            builder.Property(x => x.CreatedDate)
                .HasColumnType("timestamp");

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("timestamp");

            var currentDate = DateTime.Now;

            ContactLocationMapping contactLocationMapping = new ContactLocationMapping();

            contactLocationMapping.Id = 1;
            contactLocationMapping.HotelId = 1;
            contactLocationMapping.LocationId = 1;

            contactLocationMapping.IsActive = true;
            contactLocationMapping.IsDeleted = false;
            contactLocationMapping.AddByUserId = 1;
            contactLocationMapping.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);

           // builder.HasData(contactLocationMapping);
        }
    }
}
