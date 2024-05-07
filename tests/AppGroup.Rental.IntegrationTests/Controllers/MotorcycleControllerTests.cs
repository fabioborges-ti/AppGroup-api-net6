using AppGroup.Rental.Application.UseCases.Motorcycles.Create;
using AppGroup.Rental.Application.UseCases.Motorcycles.Update;
using RestSharp;
using System.Net;

namespace AppGroup.Rental.IntegrationTests.Controllers;

public class MotorcycleControllerTests
{
    [Fact]
    [Trait($"Controllers - {nameof(MotorcycleControllerTests)}", "V1")]
    public async Task CreateMotorcycle_ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v1/Motorcycle", Method.Post);

        var body = new CreateMotorcyclesRequest
        {
            Model = "Honda Biz 100",
            PlateNumber = "ABC0001",
            Year = 2010
        };

        requestRest.AddJsonBody(body);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("\"Registration 'ABC0001' already exists\"", response.Content);
    }

    [Fact]
    [Trait($"Controllers - {nameof(MotorcycleControllerTests)}", "V1")]
    public async Task PatchMotorcycle_ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest("https://localhost:8081/api/v1/Motorcycle", Method.Patch);

        var body = new UpdateMotorCycleRequest
        {
            Id = Guid.NewGuid(),
            PlateNumber = "ABC0001",
        };

        requestRest.AddJsonBody(body);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("\"register not found\"", response.Content);
    }
}
