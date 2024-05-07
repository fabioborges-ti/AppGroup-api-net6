using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Get.Handlers.Handlers;

public class GetDataHandler : Handler<GetMotodriversRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetDataHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(GetMotodriversRequest request)
    {
        try
        {
            var page = request.Page;
            var pagesize = request.Pagesize;

            var result = await _repository.GetPaged(page, pagesize);

            request.Items = result;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
