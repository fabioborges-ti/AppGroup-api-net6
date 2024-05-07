using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Prices;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using System.Globalization;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetPrices.Handlers;

public class GetPricesHandler : Handler<GetPricesRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public GetPricesHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetPricesRequest request)
    {
        try
        {
            var data = await _repository.GetPrices();

            var result = data.Select(p =>
                new FormattedPricesDto
                {
                    Id = p.Id,
                    Days = $"{p.Days} days",
                    Daily = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", p.Daily)
                }).ToList();

            request.Prices = result;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
