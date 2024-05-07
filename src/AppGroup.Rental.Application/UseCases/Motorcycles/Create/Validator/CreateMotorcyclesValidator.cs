using FluentValidation;

namespace AppGroup.Rental.Application.UseCases.Motorcycles.Create.Validator;

public class CreateMotorcyclesValidator : AbstractValidator<CreateMotorcyclesRequest>
{
    public CreateMotorcyclesValidator()
    {
        RuleFor(c => c.Model)
            .NotEmpty().WithMessage("Please, enter the motorcycle model.")
            .NotNull().WithMessage("Please, enter the motorcycle model.");

        RuleFor(c => c.PlateNumber)
            .NotEmpty().WithMessage("Please, enter the plate number.")
            .NotNull().WithMessage("Please, enter the plate number.")
            .Length(7).WithMessage("Only 7 characters are accepted");

        RuleFor(c => c.Year)
            .GreaterThan(0).WithMessage("Please, enter the year.");
    }
}
