#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Create;

public class CreateMotodriversRequest : RequestBaseDto, IRequest<CreateMotodriversResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public string Cnh { get; set; } = string.Empty;
    public CnhTypes CnhType { get; set; } = CnhTypes.A;

    [JsonIgnore]
    public MotodriverDto Motodriver { get; set; }
}
