using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Update.Handlers;

public class CheckIfExistsHandler : Handler<UpdateMotorCycleRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public CheckIfExistsHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UpdateMotorCycleRequest request)
    {
        var id = request.Id;
        var plateNumber = request.PlateNumber;

        try
        {
            var exists = await _repository.GetById(id);

            if (exists is null)
            {
                request.HasError = true;
                request.ErrorMessage = "register not found";
                return;
            }

            var plateNumberExists = await _repository.GetByPlateNumber(plateNumber);

            if (plateNumberExists is not null)
            {
                request.HasError = true;
                request.ErrorMessage = $"This motorcycle '{plateNumber}' already exists.";
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
