using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class MotorcycleConfiguration : IEntityTypeConfiguration<MotorcycleEntity>
{
    public void Configure(EntityTypeBuilder<MotorcycleEntity> builder)
    {
        builder.ToTable("tb_motorcycles");

        builder.HasIndex(c => c.PlateNumber).IsUnique();
    }
}
