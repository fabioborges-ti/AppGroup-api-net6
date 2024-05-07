#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.ActiveRent;

public class ActiveRentRequest : RequestBaseDto, IRequest<ActiveRentResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetRentDto Rent { get; set; }
}
