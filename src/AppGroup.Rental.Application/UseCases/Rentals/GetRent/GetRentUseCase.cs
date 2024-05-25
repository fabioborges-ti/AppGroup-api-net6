using AppGroup.Rental.Application.UseCases.Rentals.GetRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRent;

public class GetRentUseCase : IRequestHandler<GetRentRequest, GetRentResponse>
{
    private readonly IRentRepository _repository;

    public GetRentUseCase(IRentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetRentResponse> Handle(GetRentRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(GetRentUseCase), DateTime.UtcNow);

        var h1 = new GetDataRentHandler(_repository);

        await h1.Process(request);

        return new GetRentResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Proposal,
        };
    }
}
