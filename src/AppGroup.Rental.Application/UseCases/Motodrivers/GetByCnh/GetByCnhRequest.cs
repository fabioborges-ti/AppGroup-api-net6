#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.GetByCnh;

public class GetByCnhRequest : RequestBaseDto, IRequest<GetByCnhResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetMotodriverDto Motodriver { get; set; }
}
