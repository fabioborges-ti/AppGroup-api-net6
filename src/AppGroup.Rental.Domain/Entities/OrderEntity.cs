#nullable disable

using AppGroup.Rental.Domain.Common.Entities;
using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Entities;

public class OrderEntity : AuditableEntity
{
    public double RaceValue { get; set; }
    public StatusOrder Status { get; set; }
    public Guid? MotodriverId { get; set; }

    // POO
    public MotodriverEntity Motodriver { get; set; }
    public ICollection<NotificationEntity> Notifications { get; set; }
}
