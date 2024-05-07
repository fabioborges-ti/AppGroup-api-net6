using AppGroup.Rental.Application.UseCases.Motodrivers.GetByCnh.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.GetByCnh;

public class GetByCnhUseCase : IRequestHandler<GetByCnhRequest, GetByCnhResponse>
{
    private readonly IMotodriversRepository _repository;

    public GetByCnhUseCase(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByCnhResponse> Handle(GetByCnhRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetByCnhHandler(_repository);

        await h1.Process(request);

        return new GetByCnhResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motodriver
        };
    }
}
