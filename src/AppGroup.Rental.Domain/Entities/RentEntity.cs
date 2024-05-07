using AppGroup.Rental.Domain.Common.Entities;
using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Entities;

public class RentEntity : AuditableEntity
{
    public DateTime Start { get; set; }
    public DateTime Forecast { get; set; }
    public DateTime? End { get; set; }
    public double? ValueForecast { get; set; }
    public double? TotalPrice { get; set; }
    public StatusRent Status { get; set; }

    // MER
    public Guid MotodriverId { get; set; }
    public Guid MotorcycleId { get; set; }
    public Guid PriceId { get; set; }

    // POO
    public MotodriverEntity? Motodriver { get; set; }
    public MotorcycleEntity? Motorcycle { get; set; }
    public PriceEntity? Price { get; set; }
}
