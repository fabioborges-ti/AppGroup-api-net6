#nullable disable

using AppGroup.Rental.Domain.Dtos.Http;
using AppGroup.Rental.Domain.Dtos.Rent;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetRents;

public class GetRentsRequest : RequestBaseDto, IRequest<GetRentsResponse>
{
    [JsonIgnore]
    public List<GetRentDto> Rents { get; set; }
}
