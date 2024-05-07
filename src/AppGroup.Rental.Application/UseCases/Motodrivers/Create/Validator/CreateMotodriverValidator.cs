using AppGroup.Rental.Application.Common.Functions;
using FluentValidation;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.Create.Validator;

public class CreateMotodriverValidator : AbstractValidator<CreateMotodriversRequest>
{
    public CreateMotodriverValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Please, provide your name.")
            .NotNull().WithMessage("Please, provide your name.");

        RuleFor(c => c.Cnpj)
            .NotEmpty().WithMessage("Please, provide your cnpj.")
            .Length(14).WithMessage("This document must contain 14 digits.")
            .Must(Utils.BeValidCNPJ).WithMessage("Invalid CNPJ.");

        RuleFor(c => c.Cnh)
            .NotEmpty().WithMessage("Please, provide your cnh.")
            .Matches("^[0-9]*$").WithMessage("The number must contain only numeric digits.")
            .Length(11).WithMessage("This document must contain 11 digits.");

        RuleFor(c => c.Birthday)
            .NotEmpty().WithMessage("Please, provide your birthday.")
            .NotNull().WithMessage("Please, provide your birthday.");
    }
}
