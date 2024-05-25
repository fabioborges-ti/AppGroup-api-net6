using AppGroup.Rental.Application.UseCases.Motorcycles.Get.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Get;

public class GetMotorcyclesUseCase : IRequestHandler<GetMotorcyclesRequest, GetMotorcyclesResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public GetMotorcyclesUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetMotorcyclesResponse> Handle(GetMotorcyclesRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(GetMotorcyclesUseCase), DateTime.UtcNow);

        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new GetMotorcyclesResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motorcycles,
        };
    }
}
