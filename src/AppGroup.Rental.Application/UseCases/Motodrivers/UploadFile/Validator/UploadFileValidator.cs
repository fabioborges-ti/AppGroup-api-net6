using FluentValidation;

namespace AppGroup.Rental.Application.UseCases.Motodrivers.UploadFile.Validator;

public class UploadFileValidator : AbstractValidator<UploadFileRequest>
{
    public UploadFileValidator()
    {
        RuleFor(c => c.Cnh)
            .NotEmpty().WithMessage("Please, provide your driver's license number.")
            .NotNull().WithMessage("Please, provide your driver's license number.");

        RuleFor(c => c.FileName)
            .NotEmpty().WithMessage("The file name cannot be empty.")
            .Matches(@"^.+\.(bmp|jpg)$").WithMessage("The file name must have the extension .bmp or .jpg");

        RuleFor(c => c.Base64File)
            .NotEmpty().WithMessage("Please, provide valid content.")
            .NotNull().WithMessage("Please, provide valid content.");
    }
}
