using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRent.Handlers;

public class GetDataRentHandler : Handler<GetRentRequest>
{
    private readonly IRentRepository _repository;

    public GetDataRentHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetRentRequest request)
    {
        try
        {
            var id = request.Id;

            var data = await _repository.GetRent(id);

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Proposal not found.";
                return;
            }

            request.Proposal = data;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
