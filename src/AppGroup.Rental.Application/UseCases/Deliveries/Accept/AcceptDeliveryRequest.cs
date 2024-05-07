#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Accept;

public class AcceptDeliveryRequest : RequestBaseDto, IRequest<AcceptDeliveryResponse>
{
    public Guid OrderId { get; set; }
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetMotodriverDto Motodriver { get; set; }
}
