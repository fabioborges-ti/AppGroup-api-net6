#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Notifications;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Orders.ListNotification;

public class ListNotificationRequest : RequestBaseDto, IRequest<ListNotificationResponse>
{
    [JsonIgnore]
    public IEnumerable<NotificationDto> Notifications { get; set; }
}
