using AppGroup.Rental.Application.UseCases.Orders.Create.Handlers;
using AppGroup.Rental.Domain.Interfaces.Message;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Orders.Create;

public class CreateOrderUseCase : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRentRepository _rentRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IMessage _message;

    public CreateOrderUseCase(IOrderRepository orderRepository, IRentRepository rentRepository, INotificationRepository notificationRepository, IMessage message)
    {
        _orderRepository = orderRepository;
        _rentRepository = rentRepository;
        _notificationRepository = notificationRepository;
        _message = message;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var h1 = new CreateOrderHandler(_orderRepository);
        var h2 = new GetAvaiablesMotodriversHandler(_rentRepository, _notificationRepository);
        var h3 = new CreateNotificationsHandler(_notificationRepository);
        var h4 = new OrderNotificationHandler(_message);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);

        await h1.Process(request);

        return new CreateOrderResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : "Order created successfully."
        };
    }
}
