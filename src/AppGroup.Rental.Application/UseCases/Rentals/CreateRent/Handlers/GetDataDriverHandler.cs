using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class GetDataDriverHandler : Handler<RentRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetDataDriverHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RentRequest request)
    {
        try
        {
            var id = request.MotodriverId;

            var data = await _repository.GetById(id);

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Motordriver not found";
                return;
            }

            if (data.CnhType is not CnhTypes.A)
            {
                request.HasError = true;
                request.ErrorMessage = "Your license is invalid for rental.";
                return;
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
