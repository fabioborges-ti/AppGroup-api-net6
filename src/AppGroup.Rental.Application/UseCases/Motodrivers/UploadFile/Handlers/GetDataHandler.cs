using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile.Handlers;

public class GetDataHandler : Handler<UploadFileRequest>
{
    private readonly IMotodriversRepository _repository;

    public GetDataHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UploadFileRequest request)
    {
        var cnh = request.Cnh;

        try
        {
            var data = await _repository.GetByCnh(cnh);

            if (data is null)
            {
                request.HasError = true;
                request.ErrorMessage = $"document {cnh} not found";

                return;
            }

            request.Id = data.Id;
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
