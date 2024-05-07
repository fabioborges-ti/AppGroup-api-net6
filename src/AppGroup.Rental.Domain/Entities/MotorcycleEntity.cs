using AppGroup.Rental.Domain.Common.Entities;
using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Entities;

public class MotorcycleEntity : AuditableEntity
{
    public string? Model { get; set; }
    public string? PlateNumber { get; set; }
    public int Year { get; set; }
    public StatusMotorcycles Status { get; set; }

    // POO
    public ICollection<RentEntity>? Locations { get; set; }
    public ICollection<NotificationEntity>? Notifications { get; set; }
    public ICollection<OrderEntity>? Orders { get; set; }
}
