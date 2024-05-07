using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Deliveries;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close.Handlers;

public class UpdateOrderHandler : Handler<CloseDeliveryRequest>
{
    private readonly IDeliveryRepository _repository;

    public UpdateOrderHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CloseDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var order = new CloseDeliveryDto
            {
                OrderId = request.OrderId,
                MotodriverId = request.MotodriverId,
                Status = (int)StatusOrder.Delivered,
            };

            await _repository.CloseDelivery(order);
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
