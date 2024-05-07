using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class GetDataPriceHandler : Handler<RentRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetDataPriceHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RentRequest request)
    {
        if (request.HasError) return;

        try
        {
            var id = request.PriceId;

            var price = await _repository.GetPriceById(id);

            if (price is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Price not found.";
                return;
            }

            request.Price = price;
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
