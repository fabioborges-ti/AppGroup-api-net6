using AppGroup.Rental.Domain.Enums;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Domain.Dtos.Rent;

public class GetRentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public string Cnh { get; set; } = string.Empty;
    public CnhTypes CnhType { get; set; }
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int Year { get; set; }
    public DateTime Start { get; set; }
    public DateTime Forecast { get; set; }
    public double ValueForecast { get; set; }
    public StatusRent Status { get; set; }
    public int Days { get; set; }
    public double Daily { get; set; }
    public double? TotalPrice { get; set; }

    [JsonIgnore]
    public Guid MotodriverId { get; set; }
}
