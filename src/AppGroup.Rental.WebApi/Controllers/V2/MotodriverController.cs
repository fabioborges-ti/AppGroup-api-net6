using AppGroup.Rental.Application.UseCases.Motodrivers.Create;
using AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class MotodriverController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateMotodriversResponse>> Post(CreateMotodriversRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : CreatedAtAction(nameof(Post), result.Data);
    }

    [HttpPost("base64File")]
    public async Task<ActionResult<UploadFileRequest>> Upload([FromBody] UploadFileRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
