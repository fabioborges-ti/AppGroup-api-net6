using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class MotodriverConfiguration : IEntityTypeConfiguration<MotodriverEntity>
{
    public void Configure(EntityTypeBuilder<MotodriverEntity> builder)
    {
        builder.ToTable("tb_motodrivers");

        builder.HasIndex(c => c.Cnpj).IsUnique();
        builder.HasIndex(c => c.Cnh).IsUnique();

        builder
            .HasMany(x => x.Notifications)
            .WithOne(x => x.Motodriver)
            .HasForeignKey(x => x.MotodriverId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Motodrivers_Notifications");

        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Motodriver)
            .HasForeignKey(x => x.MotodriverId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Motodrivers_Orders");
    }
}
