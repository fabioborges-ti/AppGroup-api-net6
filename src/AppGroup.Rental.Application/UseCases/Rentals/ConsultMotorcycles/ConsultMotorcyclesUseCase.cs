using AppGroup.Rental.Application.UseCases.Rentals.ConsultMotorcycles.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Rentals.ConsultMotorcycles;

public class ConsultMotorcyclesUseCase : IRequestHandler<ConsultMotorcyclesRequest, ConsultMotorcyclesResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public ConsultMotorcyclesUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<ConsultMotorcyclesResponse> Handle(ConsultMotorcyclesRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(ConsultMotorcyclesUseCase), DateTime.UtcNow);

        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new ConsultMotorcyclesResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motorcycles
        };
    }
}
