#nullable disable

using AppGroup.Rental.Domain.Dtos.Deliveries;
using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Dtos.Notifications;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get;

public class GetDeliveryRequest : RequestBaseDto, IRequest<GetDeliveryResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetMotodriverDto Motodriver { get; set; }

    [JsonIgnore]
    public PendingDeliveryDto Delivery { get; set; }

    [JsonIgnore]
    public CreateNotificationsDto Notification { get; set; } = new();
}
