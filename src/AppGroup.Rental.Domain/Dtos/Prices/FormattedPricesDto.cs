#nullable disable

namespace AppGroup.Rental.Domain.Dtos.Prices;

public class FormattedPricesDto
{
    public Guid Id { get; set; }
    public string Days { get; set; }
    public string Daily { get; set; }
}
