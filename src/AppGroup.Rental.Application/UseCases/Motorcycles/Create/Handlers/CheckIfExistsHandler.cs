using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Create.Handlers;

public class CheckIfExistsHandler : Handler<CreateMotorcyclesRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public CheckIfExistsHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateMotorcyclesRequest request)
    {
        var plateNumber = request.PlateNumber;

        try
        {
            var exists = await _repository.CheckIfExists(plateNumber!);

            if (exists)
            {
                request.HasError = true;
                request.ErrorMessage = $"Registration '{plateNumber}' already exists";
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
