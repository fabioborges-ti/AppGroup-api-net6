using AppGroup.Rental.Application.UseCases.Deliveries.Details.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

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
        Log.Information("{usecase} started at {time}", nameof(GetDatailsUseCase), DateTime.UtcNow);

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
