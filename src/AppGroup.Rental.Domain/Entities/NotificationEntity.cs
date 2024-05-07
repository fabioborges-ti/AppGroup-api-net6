#nullable disable

using AppGroup.Rental.Domain.Common.Entities;

namespace AppGroup.Rental.Domain.Entities;

public class NotificationEntity : AuditableEntity
{
    public Guid OrderId { get; set; }
    public OrderEntity Order { get; set; }

    public Guid MotodriverId { get; set; }
    public MotodriverEntity Motodriver { get; set; }
}
