namespace AppGroup.Rental.Domain.Dtos.Motorcycles;

public class MotorcycleAvailableDto
{
    public Guid Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
}
