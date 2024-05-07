using AppGroup.Rental.Application.UseCases.Motodrivers.Create.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Create;

public class CreateMotodriversUseCase : IRequestHandler<CreateMotodriversRequest, CreateMotodriversResponse>
{
    private readonly IMotodriversRepository _repository;

    public CreateMotodriversUseCase(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateMotodriversResponse> Handle(CreateMotodriversRequest request, CancellationToken cancellationToken)
    {
        var h1 = new CheckIfExistsHandler(_repository);
        var h2 = new SaveDataHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new CreateMotodriversResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Motodriver,
        };
    }
}
