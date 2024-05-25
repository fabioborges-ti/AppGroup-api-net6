using AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber;

public class GetByPlateNumberUseCase : IRequestHandler<GetByPlateNumberRequest, GetByPlateNumberResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public GetByPlateNumberUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByPlateNumberResponse> Handle(GetByPlateNumberRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(GetByPlateNumberUseCase), DateTime.UtcNow);

        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new GetByPlateNumberResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motorcycle,
        };
    }
}
