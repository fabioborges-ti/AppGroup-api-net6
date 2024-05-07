using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class GetDataMotoHandler : Handler<RentRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetDataMotoHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RentRequest request)
    {
        if (request.HasError) return;

        try
        {
            var id = request.MotorcycleId;

            var data = await _repository.GetById(id);

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Motorcycle not found";
                return;
            }

            if (data.Status is StatusMotorcycles.Leased)
            {
                request.HasError = true;
                request.ErrorMessage = "Motorcycle is not currently available.";
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
