using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close.Handlers;

public class UpdateNotificationHandler : Handler<CloseDeliveryRequest>
{
    private readonly INotificationRepository _repository;

    public UpdateNotificationHandler(INotificationRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CloseDeliveryRequest request)
    {
        try
        {
            var orderId = request.OrderId;
            var motodriverId = request.MotodriverId;

            await _repository.Update(orderId, motodriverId);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
