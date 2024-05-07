using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Orders;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Orders.Create.Handlers;

public class CreateOrderHandler : Handler<CreateOrderRequest>
{
    private readonly IOrderRepository _repository;

    public CreateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        try
        {
            var order = new CreateOrderDto
            {
                RaceValue = request.RaceValue,
            };

            var result = await _repository.CreateOrder(order);

            request.Order = new CreateOrderDto
            {
                Id = order.Id,
                RaceValue = order.RaceValue,
                CreatedAt = order.CreatedAt,
            };
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
