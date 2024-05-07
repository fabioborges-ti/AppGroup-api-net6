using AppGroup.Rental.Domain.Dtos.Deliveries;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface IDeliveryRepository
{
    Task<PendingDeliveryDto> GetPendingDelivery();
    Task<PendingDeliveryDto> GetPendingDelivery(string cnh);
    Task AcceptDelivery(AcceptDeliveryDto delivery);
    Task<bool> CheckIfExistPendingDelivery(Guid motodriverId);
    Task<bool> CheckIfExistDelivery(Guid orderId, Guid motodriverId);
    Task CloseDelivery(CloseDeliveryDto order);
}
