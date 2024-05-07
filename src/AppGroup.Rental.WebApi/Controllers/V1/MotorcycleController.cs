using AppGroup.Rental.Application.UseCases.Motorcycles.Create;
using AppGroup.Rental.Application.UseCases.Motorcycles.Create.Validator;
using AppGroup.Rental.Application.UseCases.Motorcycles.Delete;
using AppGroup.Rental.Application.UseCases.Motorcycles.Get;
using AppGroup.Rental.Application.UseCases.Motorcycles.GetByPlateNumber;
using AppGroup.Rental.Application.UseCases.Motorcycles.Update;
using AppGroup.Rental.Domain.Enums;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppGroup.Rental.WebApi.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class MotorcycleController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateMotorcyclesResponse>> Post(CreateMotorcyclesRequest request)
    {
        #region VALIDATOR

        var validator = new CreateMotorcyclesValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(c => new { Field = c.PropertyName, Message = c.ErrorMessage }).ToList());

        #endregion

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : CreatedAtAction(nameof(Post), result.Data);
    }

    [HttpGet]
    public async Task<ActionResult<GetMotorcyclesResponse>> GetPaged([FromQuery] int page, int pagesize, StatusMotorcycles status)
    {
        var request = new GetMotorcyclesRequest { Page = page, Pagesize = pagesize, Status = status };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpGet("{plateNumber}")]
    public async Task<ActionResult<GetByPlateNumberResponse>> GetByPlateNumber([FromRoute] string plateNumber)
    {
        var request = new GetByPlateNumberRequest { PlateNumber = plateNumber };

        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateMotorCycleResponse>> Patch([FromBody] UpdateMotorCycleRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }

    [HttpDelete]
    public async Task<ActionResult<GetByPlateNumberResponse>> Delete([FromBody] DeleteMotorcycleRequest request)
    {
        var result = await Mediator.Send(request);

        return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
    }
}
