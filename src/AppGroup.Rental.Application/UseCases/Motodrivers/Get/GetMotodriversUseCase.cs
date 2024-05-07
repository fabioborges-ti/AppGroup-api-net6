using AppGroup.Rental.Application.UseCases.Motodrivers.Get.Handlers.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Get;

public class GetMotodriversUseCase : IRequestHandler<GetMotodriversRequest, GetMotodriversResponse>
{
    private readonly IMotodriversRepository _repository;

    public GetMotodriversUseCase(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetMotodriversResponse> Handle(GetMotodriversRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new GetMotodriversResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Items,
        };
    }
}
