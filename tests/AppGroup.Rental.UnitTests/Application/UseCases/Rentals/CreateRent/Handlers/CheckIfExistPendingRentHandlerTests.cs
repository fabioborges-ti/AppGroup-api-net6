using AppGroup.Rental.Application.UseCases.Rentals.CreateRent;
using AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using Moq;

namespace AppGroup.Rental.UnitTests.Application.UseCases.Rentals.CreateRent.Handlers;

public class CheckIfExistPendingRentHandlerTests
{
    private readonly Mock<IRentRepository> _repository = new();

    private readonly CheckIfExistPendingRentHandler _handler;

    public CheckIfExistPendingRentHandlerTests()
    {
        _handler = new CheckIfExistPendingRentHandler(_repository.Object);
    }

    [Fact]
    [Trait($"Handlers - {nameof(CheckIfExistPendingRentHandlerTests)}", "V1")]
    public void ProcessTest_ShouldReturn_Success()
    {
        _repository
            .Setup(r => r.CheckIfExistsPendingRent(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(false);

        var request = new RentRequest
        {
            MotodriverId = Guid.NewGuid(),
            MotorcycleId = Guid.NewGuid(),
        };

        var result = _handler.Process(request);

        Assert.NotNull(result);
        Assert.False(request.HasError);
    }

    [Fact]
    [Trait($"Handlers - {nameof(CheckIfExistPendingRentHandlerTests)}", "V1")]
    public void ProcessTest_ShouldReturn_Error()
    {
        _repository
            .Setup(r => r.CheckIfExistsPendingRent(It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(true);

        var request = new RentRequest
        {
            MotodriverId = Guid.NewGuid(),
            MotorcycleId = Guid.NewGuid(),
        };

        var result = _handler.Process(request);

        Assert.NotNull(result);
        Assert.True(request.HasError);
    }
}
