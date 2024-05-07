using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("tb_orders");

        builder
            .HasOne(x => x.Motodriver)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.MotodriverId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Orders_Motodrivers");

        builder
            .HasMany(x => x.Notifications)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Orders_Notifications");
    }
}
