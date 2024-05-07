#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Create;

public class CreateMotorcyclesRequest : RequestBaseDto, IRequest<CreateMotorcyclesResponse>
{
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int Year { get; set; }

    [JsonIgnore]
    public MotorcyclesDto Motorcycle { get; set; }
}
