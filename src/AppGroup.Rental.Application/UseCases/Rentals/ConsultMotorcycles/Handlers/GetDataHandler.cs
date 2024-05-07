using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.ConsultMotorcycles.Handlers;

public class GetDataHandler : Handler<ConsultMotorcyclesRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ConsultMotorcyclesRequest request)
    {
        try
        {
            var page = request.Page;
            var pagesize = request.Pagesize;
            var status = (int)request.Status;

            var data = await _repository.GetPaged(page, pagesize, status);

            request.Motorcycles = data;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
