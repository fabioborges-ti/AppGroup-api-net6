using AppGroup.Rental.Domain.Enums;

namespace AppGroup.Rental.Domain.Dtos.Motodrivers;

public class CreateMotodriverDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public string Cnh { get; set; } = string.Empty;
    public CnhTypes CnhType { get; set; } = CnhTypes.A;
    public string CnhImage { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
