using AppGroup.Rental.Application.UseCases.Rentals.EndRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using System.Globalization;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent;

public class EndRentUseCase : IRequestHandler<EndRentRequest, EndRentResponse>
{
    private readonly IRentRepository _rentRepository;
    private readonly IDeliveryRepository _deliveryRepository;

    public EndRentUseCase(IRentRepository rentRepository, IDeliveryRepository deliveryRepository)
    {
        _rentRepository = rentRepository;
        _deliveryRepository = deliveryRepository;
    }

    public async Task<EndRentResponse> Handle(EndRentRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetRentDataHandler(_rentRepository);
        var h2 = new CheckPendingDeliveryHandler(_deliveryRepository);
        var h3 = new CalculateValueHandler();
        var h4 = new SaveDataHandler(_rentRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);

        await h1.Process(request);

        return new EndRentResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Final rental value: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", request.TotalPrice)}",
        };
    }
}
