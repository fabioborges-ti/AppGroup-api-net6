using AppGroup.Rental.Application.UseCases.Rentals.CreateRent.Handlers;
using AppGroup.Rental.Domain.Interfaces.Repositories;
using MediatR;

namespace AppGroup.Rental.Application.UseCases.Rentals.CreateRent;

public class RentUseCase : IRequestHandler<RentRequest, RentResponse>
{
    private readonly IMotodriversRepository _motodriversRepository;
    private readonly IMotorcyclesRepository _motorcyclesRepository;
    private readonly IRentRepository _rentRepository;

    public RentUseCase(IMotodriversRepository motodriversRepository, IMotorcyclesRepository motorcyclesRepository, IRentRepository rentRepository)
    {
        _motodriversRepository = motodriversRepository;
        _motorcyclesRepository = motorcyclesRepository;
        _rentRepository = rentRepository;
    }

    public async Task<RentResponse> Handle(RentRequest request, CancellationToken cancellationToken)
    {
        var h1 = new CheckIfExistPendingRentHandler(_rentRepository);
        var h2 = new GetDataDriverHandler(_motodriversRepository);
        var h3 = new GetDataPriceHandler(_motorcyclesRepository);
        var h4 = new GetDataMotoHandler(_motorcyclesRepository);
        var h5 = new CalculateValuesHandler();
        var h6 = new CreateProposalHandler(_rentRepository);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);
        h3.SetSuccessor(h4);
        h4.SetSuccessor(h5);
        h5.SetSuccessor(h6);

        await h1.Process(request);

        return new RentResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : $"Proposal '{request.ProposalId}' was generated successfully, however it is pending. It must be accepted!",
        };
    }
}
