using AppGroup.Rental.Application.Common.Handlers;
using AppGroup.Rental.Domain.Dtos.Rent;
using AppGroup.Rental.Domain.Interfaces.Repositories;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;

public class CreateProposalHandler : Handler<RentRequest>
{
    private readonly IRentRepository _repository;

    public CreateProposalHandler(IRentRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(RentRequest request)
    {
        if (request.HasError) return;

        try
        {
            var proposal = new CreateProposalDto
            {
                MotodriverId = request.MotodriverId,
                MotorcycleId = request.MotorcycleId,
                PriceId = request.PriceId,
                Start = request.Start,
                Forecast = request.Forecast,
                ValueForecast = request.ValueForecast,
            };

            request.ProposalId = await _repository.Create(proposal);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;
            return;
        }
    }
}
