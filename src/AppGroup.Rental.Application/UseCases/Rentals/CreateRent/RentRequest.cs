#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Dtos.Prices;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent;

public class RentRequest : RequestBaseDto, IRequest<RentResponse>
{
    public Guid MotodriverId { get; set; }
    public Guid MotorcycleId { get; set; }
    public Guid PriceId { get; set; }

    [JsonIgnore]
    public DateTime Start { get; set; }

    [JsonIgnore]
    public DateTime Forecast { get; set; }

    [JsonIgnore]
    public GetMotodriverDto Motodriver { get; set; }

    [JsonIgnore]
    public MotorcyclesDto Motorcycle { get; set; }

    [JsonIgnore]
    public GetPricesDto Price { get; set; }

    [JsonIgnore]
    public double ValueForecast { get; set; }

    [JsonIgnore]
    public Guid ProposalId { get; set; }
}
