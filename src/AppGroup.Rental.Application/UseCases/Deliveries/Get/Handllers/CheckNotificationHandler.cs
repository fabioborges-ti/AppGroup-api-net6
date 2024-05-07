using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Notifications;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;

public class CheckNotificationHandler : Handler<GetDeliveryRequest>
{
    private readonly INotificationRepository _repository;

    public CheckNotificationHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var orderId = request.Delivery.Id;

            var motodriverId = request.Motodriver.Id;

            var exists = await _repository.ExistsNotificationOrder(orderId, motodriverId);

            if (!exists)
            {
                var notification = new CreateNotificationsDto
                {
                    OrderId = orderId,
                    MotodriverId = motodriverId,
                };

                request.Notification = notification;
            }
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        await _successor!.Process(request);
    }
}
