using AppGroup.Rental.Application.UseCases.Rentals.GetRents.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRents;

public class GetRentsUseCase : IRequestHandler<GetRentsRequest, GetRentsResponse>
{
    private readonly IRentRepository _repository;

    public GetRentsUseCase(IRentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetRentsResponse> Handle(GetRentsRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(GetRentsUseCase), DateTime.UtcNow);

        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new GetRentsResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Rents,
        };
    }
}
