#nullable disable

using AppGroup.Rental.Domain.Dtos.Deliveries;
using AppGroup.Rental.Domain.Dtos.Http;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Details;

public class GetDatailsRequest : RequestBaseDto, IRequest<GetDatailsResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public PendingDeliveryDto Order { get; set; }
}
