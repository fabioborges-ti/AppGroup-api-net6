using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Prices;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetPrices;

public class GetPricesRequest : RequestBaseDto, IRequest<GetPricesResponse>
{
    [JsonIgnore]
    public List<FormattedPricesDto> Prices { get; set; } = new();
}
