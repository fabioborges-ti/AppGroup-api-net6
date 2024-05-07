using AppGroup.Rental.Domain.Dtos.Http;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Delete;

public class DeleteMotorcycleRequest : RequestBaseDto, IRequest<DeleteMotorcycleResponse>
{
    public string PlateNumber { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid MotorcycleId { get; set; }
}
