using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close.Handlers;

public class CheckIfExistsHandler : Handler<CloseDeliveryRequest>
{
    private readonly IDeliveryRepository _repository;

    public CheckIfExistsHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CloseDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var cnh = request.Cnh;

            var order = await _repository.GetPendingDelivery(cnh);

            if (order is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Delivery not found";
                return;
            }

            request.OrderId = order.Id;
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
