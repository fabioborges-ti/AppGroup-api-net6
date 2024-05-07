using AppGroup.Rental.Application.UseCases.Rentals.GetRents.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRents;

public class GetRentsUseCase : IRequestHandler<GetRentsRequest, GetRentsResponse>
{
    private readonly IRentRepository _repository;

    public GetRentsUseCase(IRentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetRentsResponse> Handle(GetRentsRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDataHandler(_repository);

        await h1.Process(request);

        return new GetRentsResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Rents,
        };
    }
}
