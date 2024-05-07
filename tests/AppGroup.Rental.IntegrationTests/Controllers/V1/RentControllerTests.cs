#nullable disable

using RestSharp;
using System.Net;

namespace AppGroup.Rental.IntegrationTests.Controllers.V1;

public class RentControllerTests
{
    [Fact]
    [Trait($"Controllers - {nameof(RentControllerTests)}", "V1")]
    public async Task SearchRent_ShouldResult_BadRequest()
    {
        // Arrange
        var requestRest = new RestRequest($"https://localhost:8081/api/v1/Rent/{Guid.NewGuid()}", Method.Get);

        requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
        requestRest.Timeout = 1000000000;

        var client = new RestClient();

        // act
        var response = await client.ExecuteAsync(requestRest);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("\"Proposal not found.\"", response.Content);
    }
}
