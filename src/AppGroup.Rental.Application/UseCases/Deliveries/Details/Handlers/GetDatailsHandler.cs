using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Details.Handlers;

public class GetDatailsHandler : Handler<GetDatailsRequest>
{
    private readonly IDeliveryRepository _repository;

    public GetDatailsHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetDatailsRequest request)
    {
        try
        {
            var cnh = request.Cnh;

            var order = await _repository.GetPendingDelivery(cnh);

            if (order is null)
            {
                request.HasError = true;
                request.ErrorMessage = "There are no pending orders.";
                return;
            }

            request.Order = order;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
