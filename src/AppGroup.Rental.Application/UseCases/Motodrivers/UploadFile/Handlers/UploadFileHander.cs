using AppGroup.Rental.Application.Common.Handlers;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile.Handlers;

public class UploadFileHander : Handler<UploadFileRequest>
{
    public override async Task Process(UploadFileRequest request)
    {
        if (request.HasError) return;

        try
        {
            if (request.FileName.EndsWith("png") || request.FileName.EndsWith("bmp"))
            {
                byte[] fileBytes = Convert.FromBase64String(request.Base64File);

                var ext = GetExtension(request.FileName);

                var filename = string.Concat(request.Id, ".", ext);

                string filePath = Path.Combine("Images", filename);

                File.WriteAllBytes(filePath, fileBytes);

                request.Path = filePath;
            }
            else
            {
                request.HasError = true;
                request.ErrorMessage = "file format is invalid";

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

    private static string GetExtension(string filename)
    {
        return filename[^3..];
    }
}