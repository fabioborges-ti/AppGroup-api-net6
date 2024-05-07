#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.EndRent;

public class EndRentRequest : RequestBaseDto, IRequest<EndRentResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetRentDto Rent { get; set; } = new();

    [JsonIgnore]
    public double TotalPrice { get; set; }
}
