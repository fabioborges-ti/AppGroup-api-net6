using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Orders.ListNotification.Handlers;

public class GetNotificationsHandler : Handler<ListNotificationRequest>
{
    private readonly INotificationRepository _repository;

    public GetNotificationsHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ListNotificationRequest request)
    {
        try
        {
            var data = await _repository.ListNotifications();

            request.Notifications = data;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
