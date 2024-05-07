using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Delete.Handlers;

public class CheckIfExistsRentHandler : Handler<DeleteMotorcycleRequest>
{
    private readonly IRentRepository _repository;

    public CheckIfExistsRentHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(DeleteMotorcycleRequest request)
    {
        try
        {
            var id = request.MotorcycleId;

            var exists = await _repository.CheckIfExistRentByMotorcycleId(id);

            if (exists)
            {
                request.HasError = true;
                request.ErrorMessage = "Motorcycle cannot be deleted.";
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
