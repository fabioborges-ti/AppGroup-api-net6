using AppGroup.Rental.Application.UseCases.Rentals.GetPrices.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

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
