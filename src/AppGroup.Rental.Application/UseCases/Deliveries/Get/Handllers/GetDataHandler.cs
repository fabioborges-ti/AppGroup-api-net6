using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;

public class GetDataHandler : Handler<GetDeliveryRequest>
{
    private readonly IDeliveryRepository _repository;

    public GetDataHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetDeliveryRequest request)
    {
        try
        {
            var data = await _repository.GetPendingDelivery();

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = "There are no orders for delivery at this time";
                return;
            }

            request.Delivery = data;
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
