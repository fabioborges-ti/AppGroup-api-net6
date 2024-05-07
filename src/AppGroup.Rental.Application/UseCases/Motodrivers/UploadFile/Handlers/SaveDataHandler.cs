using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile.Handlers;

public class SaveDataHandler : Handler<UploadFileRequest>
{
    private readonly IMotodriversRepository _repository;

    public SaveDataHandler(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UploadFileRequest request)
    {
        if (request.HasError) return;

        try
        {
            var id = request.Id;
            var path = request.Path.Replace("Images\\", "");

            await _repository.UpdateImage(id, path);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
