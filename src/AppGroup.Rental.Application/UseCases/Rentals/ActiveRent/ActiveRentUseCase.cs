using AppGroup.Rental.Application.UseCases.Rentals.ActiveRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Rentals.ActiveRent;

public class ActiveRentUseCase : IRequestHandler<ActiveRentRequest, ActiveRentResponse>
{
    private readonly IRentRepository _repository;

    public ActiveRentUseCase(IRentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActiveRentResponse> Handle(ActiveRentRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new ActiveRentResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Rent
        };
    }
}
