using AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get;

public class GetDeliveryUseCase : IRequestHandler<GetDeliveryRequest, GetDeliveryResponse>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMotodriversRepository _motodriversRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationRepository _notificationRepository;

    public GetDeliveryUseCase
    (
        IDeliveryRepository deliveryRepository,
        IMotodriversRepository motodriversRepository,
        IOrderRepository orderRepository,
        INotificationRepository notificationRepository
    )
    {
        _deliveryRepository = deliveryRepository;
        _motodriversRepository = motodriversRepository;
        _orderRepository = orderRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<GetDeliveryResponse> Handle(GetDeliveryRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetMotodriverSituationHandler(_motodriversRepository);
        var h2 = new GetDataHandler(_deliveryRepository);
        var h3 = new GetMotodriverHandler(_motodriversRepository);
        var h4 = new UpdateOrderHandler(_orderRepository);
        var h5 = new CheckNotificationHandler(_notificationRepository);
        var h6 = new CreateNotificationHandler(_notificationRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);
        h4.SetSuccessor(h5);
        h5.SetSuccessor(h6);

        await h1.Process(request);

        return new GetDeliveryResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Delivery,
        };
    }
}
