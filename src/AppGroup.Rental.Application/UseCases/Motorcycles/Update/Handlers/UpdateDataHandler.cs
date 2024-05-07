using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Update.Handlers;

public class UpdateDataHandler : Handler<UpdateMotorCycleRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public UpdateDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UpdateMotorCycleRequest request)
    {
        if (request.HasError) return;

        try
        {
            var id = request.Id;
            var plateNumber = request.PlateNumber;

            await _repository.Update(id, plateNumber);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
