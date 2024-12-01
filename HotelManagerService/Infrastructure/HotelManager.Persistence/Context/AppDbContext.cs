using HotelManager.Domain.Common;
using HotelManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HotelManager.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelContact> HotelContacts { get; set; }
        public DbSet<HotelLocationContact> HotelLocationContacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ContactLocationMapping> ContactLocationMappings { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken CancellationToken = default)
        {
            int userId = 1;
            var currentDate = DateTime.Now;

            foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added).ToList())
            {
                entity.Entity.CreatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);
                entity.Entity.IsDeleted = false;
                entity.Entity.IsActive = true;
                entity.Entity.AddByUserId = userId;
            }

            foreach (var entity in ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Modified).ToList())
            {
               // entity.Entity.CreatedDate = entity.Entity.CreatedDate;
                entity.Entity.UpdatedDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, 0, DateTimeKind.Local);
                entity.Entity.UpdatedByUserId = userId;
            }

            return await base.SaveChangesAsync(CancellationToken);
        }
    }
}
