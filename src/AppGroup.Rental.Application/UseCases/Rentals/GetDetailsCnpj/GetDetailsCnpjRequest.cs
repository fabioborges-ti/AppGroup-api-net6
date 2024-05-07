#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj;

public class GetDetailsCnpjRequest : RequestBaseDto, IRequest<GetDetailsCnpjResponse>
{
    public string Cnpj { get; set; }

    [JsonIgnore]
    public DetailsCnpjDto DetailsCnpj { get; set; }
}
