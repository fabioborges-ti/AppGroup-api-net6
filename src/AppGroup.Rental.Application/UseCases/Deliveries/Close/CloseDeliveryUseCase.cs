using AppGroup.Rental.Application.UseCases.Deliveries.Close.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close;

public class CloseDeliveryUseCase : IRequestHandler<CloseDeliveryRequest, CloseDeliveryResponse>
{
    private readonly IMotodriversRepository _motodriversRepository;
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly INotificationRepository _notificationRepository;

    public CloseDeliveryUseCase(IMotodriversRepository motodriversRepository, IDeliveryRepository deliveryRepository, INotificationRepository notificationRepository)
    {
        _motodriversRepository = motodriversRepository;
        _deliveryRepository = deliveryRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<CloseDeliveryResponse> Handle(CloseDeliveryRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetMotodriverHandler(_motodriversRepository);
        var h2 = new CheckIfExistsHandler(_deliveryRepository);
        var h3 = new UpdateOrderHandler(_deliveryRepository);
        var h4 = new UpdateNotificationHandler(_notificationRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);

        await h1.Process(request);

        return new CloseDeliveryResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Order '{request.OrderId}' completed successfully."
        };
    }
}
