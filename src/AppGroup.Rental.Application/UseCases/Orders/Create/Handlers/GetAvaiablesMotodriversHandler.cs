using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Orders.Create.Handlers;

public class GetAvaiablesMotodriversHandler : Handler<CreateOrderRequest>
{
    private readonly IRentRepository _rentRepository;
    private readonly INotificationRepository _notificationRepository;

    public GetAvaiablesMotodriversHandler(IRentRepository rentRepository, INotificationRepository notificationRepository)
    {
        _rentRepository = rentRepository;
        _notificationRepository = notificationRepository;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var motocycles = await _rentRepository.GetMotodriversAvaiables();

            request.Motodrivers = motocycles;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }

        await _successor!.Process(request);
    }
}
