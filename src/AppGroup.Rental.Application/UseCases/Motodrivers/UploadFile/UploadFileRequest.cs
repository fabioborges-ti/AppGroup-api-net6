using AppGroup.Rental.Domain.Dtos.Http;
using MediatR;
using System.Text.Json.Serialization;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile;

public class UploadFileRequest : RequestBaseDto, IRequest<UploadFileResponse>
{
    public string Cnh { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Base64File { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonIgnore]
    public string Path { get; set; } = string.Empty;
}
