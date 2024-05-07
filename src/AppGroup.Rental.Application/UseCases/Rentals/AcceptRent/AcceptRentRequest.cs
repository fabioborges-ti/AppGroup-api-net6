#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.AcceptRent;

public class AcceptRentRequest : RequestBaseDto, IRequest<AcceptRentResponse>
{
    public string Cnh { get; set; }

    [JsonIgnore]
    public GetRentDto Rent { get; set; }
}
