using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent.Handlers;

public class CheckPendingDeliveryHandler : Handler<EndRentRequest>
{
    private readonly IDeliveryRepository _repository;

    public CheckPendingDeliveryHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(EndRentRequest request)
    {
        try
        {
            var motodriverId = request.Rent.MotodriverId;

            var exists = await _repository.CheckIfExistPendingDelivery(motodriverId);

            if (exists)
            {
                request.HasError = true;
                request.ErrorMessage = "Error! There is a pending delivery.";
                return;
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
