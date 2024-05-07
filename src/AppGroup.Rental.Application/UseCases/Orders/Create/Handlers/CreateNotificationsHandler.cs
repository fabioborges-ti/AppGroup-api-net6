using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Notifications;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Orders.Create.Handlers;

public class CreateNotificationsHandler : Handler<CreateOrderRequest>
{
    private readonly INotificationRepository _repository;

    public CreateNotificationsHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var orderId = request.Order.Id;

            var motodrivers = request.Motodrivers;

            var data = motodrivers.Select(c => new CreateNotificationsDto { OrderId = orderId, MotodriverId = c.Id }).ToList();

            if (data.Any())
                await _repository.Create(data);
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
