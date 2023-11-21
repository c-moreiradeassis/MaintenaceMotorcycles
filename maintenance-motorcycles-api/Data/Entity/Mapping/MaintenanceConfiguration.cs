using Data.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entity.Mapping
{
    public sealed class MaintenanceConfiguration : IEntityTypeConfiguration<MaintenanceEntity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Item).HasMaxLength(100);
            builder.Property(x => x.Operation).HasMaxLength(100);
            builder.Property(x => x.Every);
        }
    }
}
