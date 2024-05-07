namespace AppGroup.Rental.Domain.Dtos.Prices;

public class GetPricesDto
{
    public Guid Id { get; set; }
    public int Days { get; set; }
    public double Daily { get; set; }
}
