using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Deliveries.Get.Handllers;

public class GetMotodriverSituationHandler : Handler<GetDeliveryRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetMotodriverSituationHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetDeliveryRequest request)
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

            var blocked = await _repository.CheckOrderPending(cnh);

            if (blocked)
            {
                request.HasError = true;
                request.ErrorMessage = "There are pending orders for delivery.";
                return;
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
