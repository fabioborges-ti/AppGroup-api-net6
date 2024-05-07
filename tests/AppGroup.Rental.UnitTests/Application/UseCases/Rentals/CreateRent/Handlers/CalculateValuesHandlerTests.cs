using AppGroup.Rental.Application.UseCases.Rentals.CreateRent;
using AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;
using AppGroup.Rental.Domain.Dtos.Prices;

namespace AppGroup.Rental.UnitTests.Application.UseCases.Rentals.CreateRent.Handlers;

public class CalculateValuesHandlerTests
{
    [Fact]
    [Trait($"Handlers - {nameof(CalculateValuesHandlerTests)}", "V1")]
    public void ProcessTest()
    {
        // Arrange 
        var request = new RentRequest
        {
            Price = new GetPricesDto
            {
                Id = Guid.NewGuid(),
                Days = 7,
                Daily = 30,
            }
        };

        var startDateExpected = DateTime.UtcNow.Date.AddDays(1);
        var forecastDataExpected = startDateExpected.AddDays(6).Date;
        var valueForecast = request.Price.Days * request.Price.Daily;

        // act
        var handler = new CalculateValuesHandler();

        var result = handler.Process(request);

        // assert
        Assert.NotNull(result);
        Assert.Equal(startDateExpected, request.Start.Date);
        Assert.Equal(forecastDataExpected, request.Forecast.Date);
        Assert.Equal(valueForecast, request.ValueForecast);
    }
}
