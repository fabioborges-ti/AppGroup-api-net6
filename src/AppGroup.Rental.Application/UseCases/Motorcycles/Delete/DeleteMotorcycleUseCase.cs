using AppGroup.Rental.Application.UseCases.Motorcycles.Delete.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Delete;

public class DeleteMotorcycleUseCase : IRequestHandler<DeleteMotorcycleRequest, DeleteMotorcycleResponse>
{
    private readonly IMotorcyclesRepository _motorcyclesRepository;
    private readonly IRentRepository _rentRepository;

    public DeleteMotorcycleUseCase(IMotorcyclesRepository motorcyclesRepository, IRentRepository rentRepository)
    {
        _motorcyclesRepository = motorcyclesRepository;
        _rentRepository = rentRepository;
    }

    public async Task<DeleteMotorcycleResponse> Handle(DeleteMotorcycleRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetMotoDataHandler(_motorcyclesRepository);
        var h2 = new CheckIfExistsRentHandler(_rentRepository);
        var h3 = new DeleteDataHandler(_motorcyclesRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);

        await h1.Process(request);

        return new DeleteMotorcycleResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"record '{request.PlateNumber}' deleted successfully",
        };
    }
}
