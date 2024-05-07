using AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj;
using AppGroup.Rental.Application.UseCases.Rentals.GetPrices;
using AppGroup.Rental.Application.UseCases.Rentals.GetRent;
using AppGroup.Rental.Application.UseCases.Rentals.GetRents;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RentController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetRentsResponse>> Get()
    {
        var request = new GetRentsRequest();

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetRentResponse>> Get(Guid id)
    {
        var request = new GetRentRequest { Id = id };

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

    [HttpGet("DetailsCnpj/{cnpj}")]
    public async Task<ActionResult<GetDetailsCnpjResponse>> GetPrices(string cnpj)
    {
        var request = new GetDetailsCnpjRequest { Cnpj = cnpj };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
