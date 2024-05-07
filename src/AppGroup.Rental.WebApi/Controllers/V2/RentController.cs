using AppGroup.Rental.Application.UseCases.Rentals.AcceptRent;
using AppGroup.Rental.Application.UseCases.Rentals.ActiveRent;
using AppGroup.Rental.Application.UseCases.Rentals.ConsultMotorcycles;
using AppGroup.Rental.Application.UseCases.Rentals.CreateRent;
using AppGroup.Rental.Application.UseCases.Rentals.EndRent;
using AppGroup.Rental.Application.UseCases.Rentals.GetPrices;
using AppGroup.Rental.Application.UseCases.Rentals.GetRent;
using AppGroup.Rental.Domain.Enums;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RentController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<RentResponse>> StartRent([FromBody] RentRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : CreatedAtAction(nameof(StartRent), result.Data);
    }

    [HttpPatch("Accept")]
    public async Task<ActionResult<AcceptRentResponse>> Accept([FromBody] AcceptRentRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("Accept/{cnh}")]
    public async Task<ActionResult<GetRentResponse>> GetAccept(string cnh)
    {
        var request = new ActiveRentRequest { Cnh = cnh };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("GetPrices")]
    public async Task<ActionResult<GetPricesResponse>> GetPrices()
    {
        var request = new GetPricesRequest();

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("AvailableMotorcycles")]
    public async Task<ActionResult<ConsultMotorcyclesResponse>> AvailableMotorcycles([FromQuery] int page, int pagesize)
    {
        var request = new ConsultMotorcyclesRequest { Page = page, Pagesize = pagesize, Status = StatusMotorcycles.Avaiable };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPost("Close")]
    public async Task<ActionResult<EndRentResponse>> Close([FromBody] EndRentRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
