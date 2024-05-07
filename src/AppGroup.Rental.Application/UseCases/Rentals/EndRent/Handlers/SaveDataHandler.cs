using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent.Handlers;

public class SaveDataHandler : Handler<EndRentRequest>
{
    private readonly IRentRepository _repository;

    public SaveDataHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(EndRentRequest request)
    {
        try
        {
            var id = request.Rent.Id;
            var totalPrice = request.TotalPrice;
            var plateNumber = request.Rent.PlateNumber;

            await _repository.CloseRent(id, totalPrice, plateNumber);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
