using AppGroup.Rental.Application.UseCases.Motorcycles.Update.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Update;

public class UpdateMotorCycleUseCase : IRequestHandler<UpdateMotorCycleRequest, UpdateMotorCycleResponse>
{
    private readonly IMotorcyclesRepository _repository;

    public UpdateMotorCycleUseCase(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateMotorCycleResponse> Handle(UpdateMotorCycleRequest request, CancellationToken cancellationToken)
    {
        var h1 = new CheckIfExistsHandler(_repository);
        var h2 = new UpdateDataHandler(_repository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new UpdateMotorCycleResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"record '{request.Id}' updated successfully",
        };
    }
}
