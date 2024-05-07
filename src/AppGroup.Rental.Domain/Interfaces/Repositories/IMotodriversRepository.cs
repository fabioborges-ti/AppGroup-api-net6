using AppGroup.Rental.Domain.Dtos.Motodrivers;

namespace AppGroup.Rental.Domain.Interfaces.Repositories;

public interface IMotodriversRepository
{
    Task<bool> CheckIfExists(string cnpj, string cnh);
    Task<Guid> Create(CreateMotodriverDto motodriver);
    Task<GetMotodriverDto?> GetById(Guid id);
    Task<GetMotodriverDto?> GetByCnh(string cnh);
    Task UpdateImage(Guid id, string path);
    Task<GetMotoDriversPagedDto> GetPaged(int page, int pagesize);
    Task<bool> CheckOrderPending(string cnh);
}
