using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Dtos.Prices;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface IMotorcyclesRepository
{
    Task<bool> CheckIfExists(string plateNumber);
    Task<Guid> Create(CreateMotorcyclesDto motocyle);
    Task<MotorcyclesDto> GetByPlateNumber(string plateNumber);
    Task<MotorcyclesDto?> GetById(Guid id);
    Task Delete(string plateNumber);
    Task Update(Guid id, string plateNumber);
    Task<List<GetPricesDto>> GetPrices();
    Task<GetPricesDto> GetPriceById(Guid id);
    Task<GetMotorcyclesPagedDto> GetPaged(int page, int pagesize, int status);
}
