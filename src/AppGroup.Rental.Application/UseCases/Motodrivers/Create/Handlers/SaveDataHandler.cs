using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Motodrivers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Create.Handlers;

public class SaveDataHandler : Handler<CreateMotodriversRequest>
{
    private readonly IMotodriversRepository _repository;

    public SaveDataHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateMotodriversRequest request)
    {
        if (request.HasError) return;

        try
        {
            var motodriver = new CreateMotodriverDto
            {
                Name = request.Name,
                Cnpj = request.Cnpj,
                Birthday = request.Birthday,
                Cnh = request.Cnh,
                CnhType = request.CnhType,
            };

            var id = await _repository.Create(motodriver);

            request.Motodriver = new MotodriverDto
            {
                Id = id,
                Name = request.Name,
                Cnpj = request.Cnpj,
                Cnh = request.Cnh,
                CnhType = request.CnhType,
                Birthday = request.Birthday
            };
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
