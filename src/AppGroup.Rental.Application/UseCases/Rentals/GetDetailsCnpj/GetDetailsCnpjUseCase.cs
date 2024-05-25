using AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj.Handlers;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj;

public class GetDetailsCnpjUseCase : IRequestHandler<GetDetailsCnpjRequest, GetDetailsCnpjResponse>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GetDetailsCnpjUseCase(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetDetailsCnpjResponse> Handle(GetDetailsCnpjRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(GetDetailsCnpjUseCase), DateTime.UtcNow);

        var h1 = new GetDetailsHandler(_httpClientFactory);

        await h1.Process(request);

        return new GetDetailsCnpjResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.DetailsCnpj,
        };
    }
}
