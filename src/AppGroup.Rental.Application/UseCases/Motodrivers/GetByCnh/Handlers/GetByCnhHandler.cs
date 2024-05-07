using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.GetByCnh.Handlers;

public class GetByCnhHandler : Handler<GetByCnhRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetByCnhHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetByCnhRequest request)
    {
        try
        {
            var cnh = request.Cnh;

            var motodriver = await _repository.GetByCnh(cnh);

            if (motodriver is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Motodriver not found.";
                return;
            }

            request.Motodriver = motodriver;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
