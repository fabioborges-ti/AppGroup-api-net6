using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber;

public class GetByPlateNumberRequest : RequestBaseDto, IRequest<GetByPlateNumberResponse>
{
    public string PlateNumber { get; set; } = string.Empty;

    [JsonIgnore]
    public MotorcyclesDto? Motorcycle { get; set; }
}
