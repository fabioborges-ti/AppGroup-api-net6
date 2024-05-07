using AppGroup.Rental.Application.UseCases.Orders.Create;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrderController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Post(CreateOrderRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : CreatedAtAction(nameof(Post), result.Data);
    }
}
