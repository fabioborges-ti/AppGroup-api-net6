using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Notifications;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;

public class CreateNotificationHandler : Handler<GetDeliveryRequest>
{
    private readonly INotificationRepository _notificationRepository;

    public CreateNotificationHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public override async Task Process(GetDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var notification = request.Notification;

            if (notification.OrderId != Guid.Empty)
            {
                var item = new CreateNotificationsDto
                {
                    OrderId = notification!.OrderId,
                    MotodriverId = notification!.MotodriverId,
                };

                await _notificationRepository.Create(item);
            }
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
