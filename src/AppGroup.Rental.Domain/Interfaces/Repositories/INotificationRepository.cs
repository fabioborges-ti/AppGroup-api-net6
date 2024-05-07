using AppGroup.Rental.Domain.Dtos.Notifications;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface INotificationRepository
{
    Task Create(CreateNotificationsDto notification);
    Task Create(List<CreateNotificationsDto> notifications);
    Task<IEnumerable<NotificationDto>> ListNotifications();
    Task<bool> ExistsNotificationOrder(Guid orderId, Guid motodriverId);
    Task Update(Guid orderId, Guid motodriverId);
}
