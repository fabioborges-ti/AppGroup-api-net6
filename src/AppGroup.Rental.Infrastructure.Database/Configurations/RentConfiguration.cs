using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class RentConfiguration : IEntityTypeConfiguration<RentEntity>
{
    public void Configure(EntityTypeBuilder<RentEntity> builder)
    {
        builder.ToTable("tb_rents");

        builder
            .HasOne(x => x.Motodriver)
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.MotodriverId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Locations_Motodrivers");

        builder
            .HasOne(x => x.Motorcycle)
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.MotorcycleId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Locations_Motorcycles");

        builder
            .HasOne(x => x.Price)
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.PriceId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Locations_Prices");
    }
}
