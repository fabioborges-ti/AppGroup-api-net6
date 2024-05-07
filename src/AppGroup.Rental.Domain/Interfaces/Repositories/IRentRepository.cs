using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Dtos.Rent;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface IRentRepository
{
    Task<Guid> Create(CreateProposalDto proposal);
    Task<GetRentDto> GetRent(Guid id);
    Task<GetRentDto> GetRentByCnh(string cnh, int status);
    Task<bool> CheckIfExistsPendingRent(Guid motodriverId, Guid motorcycleId);
    Task AcceptRent(Guid id, string plateNumber);
    Task<bool> CheckIfExistRentByMotorcycleId(Guid id);
    Task CloseRent(Guid id, double totalPrice, string plateNumber);
    Task<List<GetMotodriverDto>> GetMotodriversAvaiables();
    Task<List<GetRentDto>> GetRents();
}
