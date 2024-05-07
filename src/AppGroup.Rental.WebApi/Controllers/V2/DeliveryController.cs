using AppGroup.Rental.Application.UseCases.Deliveries.Accept;
using AppGroup.Rental.Application.UseCases.Deliveries.Close;
using AppGroup.Rental.Application.UseCases.Deliveries.Details;
using AppGroup.Rental.Application.UseCases.Deliveries.Get;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class DeliveryController : ApiControllerBase
{
    [HttpGet("{cnh}")]
    public async Task<ActionResult<GetDeliveryResponse>> Get(string cnh)
    {
        var request = new GetDeliveryRequest { Cnh = cnh };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("Details/{cnh}")]
    public async Task<ActionResult<GetDatailsResponse>> GetDetails(string cnh)
    {
        var request = new GetDatailsRequest { Cnh = cnh };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPatch("Accept")]
    public async Task<ActionResult<AcceptDeliveryResponse>> Accept([FromBody] AcceptDeliveryRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPatch("Close/{cnh}")]
    public async Task<ActionResult<CloseDeliveryResponse>> Close(string cnh)
    {
        var request = new CloseDeliveryRequest { Cnh = cnh };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
