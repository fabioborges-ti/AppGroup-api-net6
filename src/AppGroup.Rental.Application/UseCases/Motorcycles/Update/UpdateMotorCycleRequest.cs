using AppGroup.Rental.Domain.Dtos.Http;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Update;

public class UpdateMotorCycleRequest : RequestBaseDto, IRequest<UpdateMotorCycleResponse>
{
    public Guid Id { get; set; }

    public string PlateNumber { get; set; } = string.Empty;
}
