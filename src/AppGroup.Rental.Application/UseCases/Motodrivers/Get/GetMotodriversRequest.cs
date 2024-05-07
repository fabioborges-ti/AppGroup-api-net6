#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Get;

public class GetMotodriversRequest : RequestBaseDto, IRequest<GetMotodriversResponse>
{
    public int Page { get; set; }
    public int Pagesize { get; set; }

    [JsonIgnore]
    public GetMotoDriversPagedDto Items { get; set; }
}
