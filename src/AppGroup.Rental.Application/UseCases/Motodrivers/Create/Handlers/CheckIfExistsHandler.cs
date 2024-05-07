using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Create.Handlers;

public class CheckIfExistsHandler : Handler<CreateMotodriversRequest>
{
    private readonly IMotodriversRepository _repository;

    public CheckIfExistsHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CreateMotodriversRequest request)
    {
        var cnpj = request.Cnpj;
        var cnh = request.Cnh;

        try
        {
            var exists = await _repository.CheckIfExists(cnpj, cnh);

            if (exists)
            {
                request.HasError = true;
                request.ErrorMessage = $"Registration to CNPJ '{cnpj}' or CNH '{cnh}' already exists";
            }
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }

        await _successor!.Process(request);
    }
}
