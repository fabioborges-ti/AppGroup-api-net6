using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent.Handlers;

public class GetRentDataHandler : Handler<EndRentRequest>
{
    private readonly IRentRepository _repository;

    public GetRentDataHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(EndRentRequest request)
    {
        try
        {
            var cnh = request.Cnh;
            var status = (int)StatusRent.Accept;

            var rent = await _repository.GetRentByCnh(cnh, status);

            if (rent is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Proposal not found.";
                return;
            }

            if (rent.Status is StatusRent.Open)
            {
                request.HasError = true;
                request.ErrorMessage = "Rent has not been accepted yet.";
                return;
            }

            request.Rent = rent;
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
