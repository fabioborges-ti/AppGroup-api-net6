using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.ConsultMotorcycles;

public class ConsultMotorcyclesRequest : RequestBaseDto, IRequest<ConsultMotorcyclesResponse>
{
    public int Page { get; set; }
    public int Pagesize { get; set; }
    public StatusMotorcycles Status { get; set; }

    [JsonIgnore]
    public GetMotorcyclesPagedDto Motorcycles { get; set; } = new();
}
