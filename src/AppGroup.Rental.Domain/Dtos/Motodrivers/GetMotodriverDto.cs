using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Dtos.Motodrivers;

public class GetMotodriverDto
{
    public Guid Id { get; set; }
    public CnhTypes CnhType { get; set; }
}
