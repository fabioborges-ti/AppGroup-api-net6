using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Motorcycles;
using AppGroup.Rental.Domain.Enums;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Create.Handlers;

public class SaveDataHandler : Handler<CreateMotorcyclesRequest>
{
    private readonly IMotorcyclesRepository _repository;

    public SaveDataHandler(IMotorcyclesRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateMotorcyclesRequest request)
    {
        if (request.HasError) return;

        var motocycle = new CreateMotorcyclesDto
        {
            Model = request.Model,
            PlateNumber = request.PlateNumber,
            Year = request.Year,
        };

        var id = await _repository.Create(motocycle);

        request.Motorcycle = new MotorcyclesDto
        {
            Id = id,
            Model = request.Model,
            PlateNumber = request.PlateNumber,
            Year = request.Year,
            Status = StatusMotorcycles.Avaiable,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
