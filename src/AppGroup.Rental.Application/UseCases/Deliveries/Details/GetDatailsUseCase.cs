using AppGroup.Rental.Application.UseCases.Deliveries.Details.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Details;

public class GetDatailsUseCase : IRequestHandler<GetDatailsRequest, GetDatailsResponse>
{
    private readonly IDeliveryRepository _repository;

    public GetDatailsUseCase(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetDatailsResponse> Handle(GetDatailsRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetDatailsHandler(_repository);

        await h1.Process(request);

        return new GetDatailsResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Order
        };
    }
}
