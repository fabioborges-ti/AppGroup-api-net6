using AppGroup.Rental.Domain.Dtos.Orders;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Guid> CreateOrder(CreateOrderDto order);
    Task UpdateMotodriver(Guid orderId, Guid motodriver, int status);
}
