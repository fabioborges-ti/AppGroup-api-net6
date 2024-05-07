using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Deliveries;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Accept.Handlers;

public class SaveDataHandler : Handler<AcceptDeliveryRequest>
{
    private readonly IDeliveryRepository _repository;

    public SaveDataHandler(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(AcceptDeliveryRequest request)
    {
        if (request.HasError) return;

        try
        {
            var orderId = request.OrderId;
            var motodriverId = request.Motodriver.Id;

            var acceptedDto = new AcceptDeliveryDto
            {
                OrderId = orderId,
                MotodriverId = motodriverId,
                Status = (int)StatusOrder.Accepted,
            };

            await _repository.AcceptDelivery(acceptedDto);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
