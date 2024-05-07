using AppGroup.Rental.Application.Common.Handlers;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent.Handlers;

public class CalculateValueHandler : Handler<EndRentRequest>
{
    public override async Task Process(EndRentRequest request)
    {
        var returned = DateTime.UtcNow;

        try
        {
            var days = request.Rent.Days;
            var daily = request.Rent.Daily;
            var forecast = request.Rent.Forecast;
            var valueForecast = request.Rent.ValueForecast;

            double daysUsed = 0;
            double daysRemaining = 0;
            double totalPrice = 0;

            if (returned.Date <= forecast.Date)
            {
                daysRemaining = CalculateRange(returned, forecast);

                daysUsed = days - daysRemaining;

                switch (days)
                {
                    case 7:
                        totalPrice = daysUsed * daily + daysRemaining * daily * 0.2;
                        break;

                    case 15:
                        totalPrice = daysUsed * daily + daysRemaining * daily * 0.4;
                        break;

                    case 30:
                        totalPrice = daysUsed * daily + daysRemaining * daily * 0.6;
                        break;
                }
            }
            else
            {
                daysRemaining = CalculateRange(returned, forecast.Date) * -1;

                totalPrice = valueForecast + Convert.ToDouble(daysRemaining * 50);
            }

            request.TotalPrice = totalPrice;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        static double CalculateRange(DateTime data1, DateTime data2)
        {
            var days = (data2.Date - data1.Date).Days;

            return days;
        }

        await _successor!.Process(request);
    }
}
