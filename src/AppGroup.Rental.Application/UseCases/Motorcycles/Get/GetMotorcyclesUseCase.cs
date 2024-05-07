using AppGroup.Rental.Application.UseCases.Motorcycles.Get.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

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
