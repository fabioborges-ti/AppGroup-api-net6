using AppGroup.Rental.Application.UseCases.Deliveries.Accept.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Accept;

public class AcceptDeliveryUseCase : IRequestHandler<AcceptDeliveryRequest, AcceptDeliveryResponse>
{
    private readonly IMotodriversRepository _motodriversRepository;
    private readonly IDeliveryRepository _deliveryRepository;

    public AcceptDeliveryUseCase(IMotodriversRepository motodriversRepository, IDeliveryRepository deliveryRepository)
    {
        _motodriversRepository = motodriversRepository;
        _deliveryRepository = deliveryRepository;
    }

    public async Task<AcceptDeliveryResponse> Handle(AcceptDeliveryRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetMotodriverHandler(_motodriversRepository);
        var h2 = new SaveDataHandler(_deliveryRepository);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new AcceptDeliveryResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Order '{request.OrderId}' updated successfully."
        };
    }
}
