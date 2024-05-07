using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Close.Handlers;

public class GetMotodriverHandler : Handler<CloseDeliveryRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetMotodriverHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(CloseDeliveryRequest request)
    {
        try
        {
            var cnh = request.Cnh;

            var motodriver = await _repository.GetByCnh(cnh);

            if (motodriver is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Motodriver not found";
                return;
            }

            request.MotodriverId = motodriver.Id;
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
