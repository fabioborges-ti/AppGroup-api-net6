using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Dtos.Motorcycles;

public class MotorcyclesDto
{
    public Guid Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int Year { get; set; }
    public StatusMotorcycles Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
