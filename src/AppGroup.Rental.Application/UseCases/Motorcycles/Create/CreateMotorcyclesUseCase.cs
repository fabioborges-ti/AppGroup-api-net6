using AppGroup.Rental.Application.UseCases.Motorcycles.Create.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Create;

public class CreateMotorcyclesUseCase : IRequestHandler<CreateMotorcyclesRequest, CreateMotorcyclesResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public CreateMotorcyclesUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateMotorcyclesResponse> Handle(CreateMotorcyclesRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(CreateMotorcyclesUseCase), DateTime.UtcNow);

        var h1 = new CheckIfExistsHandler(_repository);
        var h2 = new SaveDataHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new CreateMotorcyclesResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motorcycle,
        };
    }
}
