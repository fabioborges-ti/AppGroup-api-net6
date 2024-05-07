#nullable disable

namespace AppGroup.Rental.Domain.Dtos.Rabbit;

public class MessageDto
{
    public Guid OrderId { get; set; }
    public double RaceValue { get; set; }
}
