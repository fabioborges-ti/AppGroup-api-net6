using AppGroup.Rental.Application.UseCases.Rentals.GetPrices.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetPrices;

public class SearchPricesUseCase : IRequestHandler<GetPricesRequest, GetPricesResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public SearchPricesUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetPricesResponse> Handle(GetPricesRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(SearchPricesUseCase), DateTime.UtcNow);

        var h1 = new GetPricesHandler(_repository);

        await h1.Process(request);

        return new GetPricesResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Prices,
        };
    }
}
