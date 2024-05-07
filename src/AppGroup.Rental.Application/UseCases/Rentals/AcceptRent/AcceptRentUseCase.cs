using AppGroup.Rental.Application.UseCases.Rentals.AcceptRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Rentals.AcceptRent;

public class AcceptRentUseCase : IRequestHandler<AcceptRentRequest, AcceptRentResponse>
{
    private readonly IRentRepository _rentRepository;

    public AcceptRentUseCase(IRentRepository rentRepository)
    {
        _rentRepository = rentRepository;
    }

    public async Task<AcceptRentResponse> Handle(AcceptRentRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetRentDataHandler(_rentRepository);
        var h2 = new SaveDataHandler(_rentRepository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new AcceptRentResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Rent '{request.Rent.Id}' successfully accepted."
        };
    }
}
