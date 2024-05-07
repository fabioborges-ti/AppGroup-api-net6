#nullable disable

using AppGroup.Rental.Domain.Common.Entities;
using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Entities;

public class MotodriverEntity : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public string Cnh { get; set; } = string.Empty;
    public CnhTypes CnhType { get; set; } = CnhTypes.A;
    public string? CnhImage { get; set; } = string.Empty;

    // POO
    public ICollection<RentEntity>? Locations { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
    public ICollection<NotificationEntity> Notifications { get; set; }
}
