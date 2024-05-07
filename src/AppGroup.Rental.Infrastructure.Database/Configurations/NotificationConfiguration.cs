using AppGroup.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGroup.Rental.Infrastructure.Database.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        builder.ToTable("tb_notifications");

        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.OrderId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Orders_Notifications");

        builder
            .HasOne(x => x.Motodriver)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.MotodriverId)
            .HasPrincipalKey(x => x.Id)
            .HasConstraintName("FK_Orders_Motodrivers");
    }
}
