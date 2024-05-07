using AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

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
