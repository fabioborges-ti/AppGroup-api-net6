using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class PriceConfiguration : IEntityTypeConfiguration<PriceEntity>
{
    public void Configure(EntityTypeBuilder<PriceEntity> builder)
    {
        builder.ToTable("tb_prices");
    }
}
