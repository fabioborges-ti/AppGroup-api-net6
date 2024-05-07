using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Rabbit;
using AppGroup.Rental.Domain.Interfaces.Message;

namespace AppGroup.Rental.Application.UseCases.Orders.Create.Handlers;

public class OrderNotificationHandler : Handler<CreateOrderRequest>
{
    private readonly IMessage _message;

    public OrderNotificationHandler(IMessage message)
    {
        _message = message;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var orderId = request.Order.Id;
            var raceValue = request.Order.RaceValue;

            await _message.SendToEndPointAsync(new MessageDto { OrderId = orderId, RaceValue = raceValue }, "create-order");
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
