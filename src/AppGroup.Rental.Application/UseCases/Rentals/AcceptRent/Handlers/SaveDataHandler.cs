using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.AcceptRent.Handlers;

public class SaveDataHandler : Handler<AcceptRentRequest>
{
    private readonly IRentRepository _repository;

    public SaveDataHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(AcceptRentRequest request)
    {
        if (request.HasError) return;

        try
        {
            var rentId = request.Rent.Id;
            var plateNumber = request.Rent.PlateNumber;

            await _repository.AcceptRent(rentId, plateNumber);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
