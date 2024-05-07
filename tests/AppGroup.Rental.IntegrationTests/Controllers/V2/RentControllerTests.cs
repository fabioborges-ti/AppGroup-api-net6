#nullable disable

using AppGroup.Rental.Application.UseCases.Rentals.CreateRent;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Dtos.Prices;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace AppGroup.Rental.IntegrationTests.Controllers.V2;

public class RentControllerTests
{
    [Fact]
    [Trait($"Controllers - {nameof(RentControllerTests)}", "V2")]
    public async Task CheckList_ShouldResult_Ok()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v2/Rent/GetPrices", Method.Get);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        var result = JsonConvert.DeserializeObject<List<FormattedPricesDto>>(response.Content)!;

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        Assert.Equal(3, result.Count);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    [Trait($"Controllers - {nameof(RentControllerTests)}", "V2")]
    public async Task AvailableMotorcycles_ShouldResult_Ok()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v2/Rent/AvailableMotorcycles?page=1&pagesize=10", Method.Get);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        var result = JsonConvert.DeserializeObject<GetMotorcyclesPagedDto>(response.Content)!;

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Items.Any());
        Assert.IsAssignableFrom<IEnumerable<MotorcyclesDto>>(result.Items);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    [Trait($"Controllers - {nameof(RentControllerTests)}", "V2")]
    public async Task CreateRent_ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v2/Rent", Method.Post);

        var body = new RentRequest
        {
            PriceId = Guid.NewGuid(),
            MotodriverId = Guid.NewGuid(),
            MotorcycleId = Guid.NewGuid(),
        };

        requestRest.AddJsonBody(body);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("\"Motordriver not found\"", response.Content);
    }
}
