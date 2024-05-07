using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Delete.Handlers;

public class GetMotoDataHandler : Handler<DeleteMotorcycleRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetMotoDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(DeleteMotorcycleRequest request)
    {
        try
        {
            var plateNumber = request.PlateNumber;

            var moto = await _repository.GetByPlateNumber(request.PlateNumber);

            if (moto is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Motorcycle not found.";
                return;
            }

            request.MotorcycleId = moto.Id;
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
