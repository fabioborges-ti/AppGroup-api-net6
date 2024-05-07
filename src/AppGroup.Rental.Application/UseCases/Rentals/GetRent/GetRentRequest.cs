using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRent;

public class GetRentRequest : RequestBaseDto, IRequest<GetRentResponse>
{
    public Guid Id { get; set; }

    [JsonIgnore]
    public GetRentDto? Proposal { get; set; }
}
