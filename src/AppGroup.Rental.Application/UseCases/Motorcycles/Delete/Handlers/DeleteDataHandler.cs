using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Delete.Handlers;

public class DeleteDataHandler : Handler<DeleteMotorcycleRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public DeleteDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(DeleteMotorcycleRequest request)
    {
        try
        {
            var platerNumber = request.PlateNumber;

            await _repository.Delete(platerNumber);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
