using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber.Handlers;

public class GetDataHandler : Handler<GetByPlateNumberRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetByPlateNumberRequest request)
    {
        try
        {
            var plateNumber = request.PlateNumber;

            var result = await _repository.GetByPlateNumber(plateNumber);

            request.Motorcycle = result;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
