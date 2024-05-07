using AppGroup.Rental.Application.UseCases.Motodrivers.Get;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class MotodriverController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetMotodriversResponse>> GetPaged([FromQuery] int page, int pagesize)
    {
        var request = new GetMotodriversRequest { Page = page, Pagesize = pagesize };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
