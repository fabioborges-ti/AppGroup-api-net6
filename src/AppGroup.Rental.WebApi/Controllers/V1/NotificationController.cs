using AppGroup.Rental.Application.UseCases.Orders.ListNotification;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class NotificationController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ListNotificationResponse>> Get()
    {
        var request = new ListNotificationRequest();

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
