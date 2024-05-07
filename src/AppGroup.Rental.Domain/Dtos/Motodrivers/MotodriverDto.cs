#nullable disable

using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Dtos.Motodrivers;

public class MotodriverDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnh { get; set; }
    public string Cnpj { get; set; }
    public CnhTypes CnhType { get; set; }
    public DateTime Birthday { get; set; }
}
