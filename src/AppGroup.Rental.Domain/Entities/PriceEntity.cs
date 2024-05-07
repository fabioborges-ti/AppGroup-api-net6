using AppGroup.Rental.Domain.Common.Entities;

namespace AppGroup.Rental.Domain.Entities;

public class PriceEntity : AuditableEntity
{
    public int Days { get; set; }
    public double Daily { get; set; }

    // POO
    public ICollection<RentEntity>? Locations { get; set; }
}
