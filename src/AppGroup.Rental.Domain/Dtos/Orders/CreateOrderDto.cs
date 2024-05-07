namespace AppGroup.Rental.Domain.Dtos.Orders;

public class CreateOrderDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double RaceValue { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
