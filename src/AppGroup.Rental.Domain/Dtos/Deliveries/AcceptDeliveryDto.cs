namespace AppGroup.Rental.Domain.Dtos.Deliveries;

public class AcceptDeliveryDto
{
    public Guid OrderId { get; set; }
    public Guid MotodriverId { get; set; }
    public int Status { get; set; }
}
