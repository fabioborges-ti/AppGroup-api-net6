using AppGroup.Rental.Application.Common.Functions;
using FluentValidation;

namespace AppGroup.Rental.Application.UseCases.Rentals.GetDetailsCnpj.Validator;

public class GetDetailsCnpjValidator : AbstractValidator<GetDetailsCnpjRequest>
{
    public GetDetailsCnpjValidator()
    {
        RuleFor(c => c.Cnpj)
            .NotEmpty().WithMessage("Please, provide your cnpj.")
            .Length(14).WithMessage("This document must contain 14 digits.")
            .Must(Utils.BeValidCNPJ).WithMessage("Invalid CNPJ.");
    }
}
