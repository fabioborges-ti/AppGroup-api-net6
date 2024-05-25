using AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;
using Serilog;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile;

public class UploadFileUseCase : IRequestHandler<UploadFileRequest, UploadFileResponse>
{
    private readonly IMotodriversRepository _repository;

    public UploadFileUseCase(IMotodriversRepository repository)
    {
        _repository = repository;
    }

    public async Task<UploadFileResponse> Handle(UploadFileRequest request, CancellationToken cancellationToken)
    {
        Log.Information("{usecase} started at {time}", nameof(UploadFileUseCase), DateTime.UtcNow);

        var h1 = new GetDataHandler(_repository);
        var h2 = new UploadFileHander();
        var h3 = new SaveDataHandler(_repository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);

        await h1.Process(request);

        return new UploadFileResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : "Record updated successfully.",
        };
    }
}
