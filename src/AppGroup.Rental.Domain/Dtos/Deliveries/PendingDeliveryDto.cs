namespace AppGroup.Rental.Domain.Dtos.Deliveries;

public class PendingDeliveryDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public double RaceValue { get; set; }
}
