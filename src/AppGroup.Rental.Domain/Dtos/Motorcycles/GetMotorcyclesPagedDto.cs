#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;

namespace AppGroup.Rental.Domain.Dtos.Motorcycles;

public class GetMotorcyclesPagedDto : ResponseBasePagedDto
{
    public IEnumerable<MotorcyclesDto> Items { get; set; }
}
