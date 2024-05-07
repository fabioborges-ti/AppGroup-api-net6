namespace AppGroup.Rental.Domain.Dtos.Rent;

public class CreateProposalDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Start { get; set; }
    public DateTime Forecast { get; set; }
    public double ValueForecast { get; set; }
    public Guid MotodriverId { get; set; }
    public Guid MotorcycleId { get; set; }
    public Guid PriceId { get; set; }
}
