#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close;

public class CloseDeliveryRequest : RequestBaseDto, IRequest<CloseDeliveryResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public Guid OrderId { get; set; }

    [JsonIgnore]
    public Guid MotodriverId { get; set; }
}
