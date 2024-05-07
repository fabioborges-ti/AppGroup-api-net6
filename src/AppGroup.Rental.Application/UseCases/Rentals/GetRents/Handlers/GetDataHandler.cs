using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRents.Handlers;

public class GetDataHandler : Handler<GetRentsRequest>
{
    private readonly IRentRepository _repository;

    public GetDataHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetRentsRequest request)
    {
        try
        {
            var rents = await _repository.GetRents();

            request.Rents = rents;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
