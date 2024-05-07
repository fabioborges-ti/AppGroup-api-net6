using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.ActiveRent.Handlers;

public class GetDataHandler : Handler<ActiveRentRequest>
{
    private readonly IRentRepository _repository;

    public GetDataHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ActiveRentRequest request)
    {
        try
        {
            var cnh = request.Cnh;
            var status = (int)StatusRent.Accept;

            var rent = await _repository.GetRentByCnh(cnh, status);

            if (rent is null)
            {
                request.HasError = true;
                request.ErrorMessage = "There are no active contracts for this user";
                return;
            }

            if (rent.Status is not StatusRent.Accept)
            {
                request.HasError = true;
                request.ErrorMessage = "There are no active contracts for this user";
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
    }
}
