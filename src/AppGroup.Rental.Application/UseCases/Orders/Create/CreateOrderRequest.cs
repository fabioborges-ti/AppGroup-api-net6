#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Dtos.Orders;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Orders.Create;

public class CreateOrderRequest : RequestBaseDto, IRequest<CreateOrderResponse>
{
    public double RaceValue { get; set; }

    [JsonIgnore]
    public CreateOrderDto Order { get; set; }

    [JsonIgnore]
    public List<GetMotodriverDto> Motodrivers { get; set; }
}
