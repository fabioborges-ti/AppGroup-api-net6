using AppGroup.Rental.Application.UseCases.Orders.ListNotification.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Orders.ListNotification;

public class ListNotificationUseCase : IRequestHandler<ListNotificationRequest, ListNotificationResponse>
{
    private readonly INotificationRepository _repository;

    public ListNotificationUseCase(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListNotificationResponse> Handle(ListNotificationRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetNotificationsHandler(_repository);

        await h1.Process(request);

        return new ListNotificationResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Notifications,
        };
    }
}
