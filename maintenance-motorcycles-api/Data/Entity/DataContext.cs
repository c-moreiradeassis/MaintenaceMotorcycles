using Data.Entity.Context;
using Data.Entity.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data.Entity
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MaintenanceEntity> Maintenance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaintenanceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
