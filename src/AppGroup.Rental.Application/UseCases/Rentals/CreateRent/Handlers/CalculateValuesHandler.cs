using AppGroup.Rental.Application.Common.Handlers;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class CalculateValuesHandler : Handler<RentRequest>
{
    public override async Task Process(RentRequest request)
    {
        if (request.HasError) return;

        var startDate = DateTime.UtcNow;

        var startRent = startDate.AddDays(1);
        var forecast = startDate.AddDays(request.Price.Days);
        var valueForecast = request.Price.Days * request.Price.Daily;

        request.Start = startRent;
        request.Forecast = forecast;
        request.ValueForecast = valueForecast;

        if (_successor != null)
            await _successor!.Process(request);
    }
}
