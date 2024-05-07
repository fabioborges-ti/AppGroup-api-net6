using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class CheckIfExistPendingRentHandler : Handler<RentRequest>
{
    private readonly IRentRepository _repository;

    public CheckIfExistPendingRentHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RentRequest request)
    {
        try
        {
            var motodriverId = request.MotodriverId;
            var motorcycleId = request.MotorcycleId;

            var exists = await _repository.CheckIfExistsPendingRent(motodriverId, motorcycleId);

            if (exists)
            {
                request.HasError = true;
                request.ErrorMessage = "There is an open rental for this vehicle or rider.";
                return;
            }
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        if (_successor is not null)
            await _successor!.Process(request);
    }
}
