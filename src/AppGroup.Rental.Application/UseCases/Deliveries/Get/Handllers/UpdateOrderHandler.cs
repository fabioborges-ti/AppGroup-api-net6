using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;

public class UpdateOrderHandler : Handler<GetDeliveryRequest>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public override async Task Process(GetDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var orderId = request.Delivery.Id;
            var motodriverId = request.Motodriver.Id;
            var status = (int)StatusOrder.Accepted;

            await _orderRepository.UpdateMotodriver(orderId, motodriverId, status);
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
