#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;

namespace AppGroup.Rental.Domain.Dtos.Motodrivers;

public class GetMotoDriversPagedDto : ResponseBasePagedDto
{
    public IEnumerable<MotodriverDto> Items { get; set; }
}
