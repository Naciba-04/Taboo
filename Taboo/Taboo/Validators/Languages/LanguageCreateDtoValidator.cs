using FluentValidation;
using Taboo.DTOs.Languages;

namespace Taboo.Validators.Languages;

public class LanguageCreateDtoValidator:AbstractValidator<LanguageCreateDto>
{
    public LanguageCreateDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithMessage("Code cannot be empty")
                .MaximumLength(2)
                .WithMessage("Code length cannot be more than 2");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name cannot be empty")
                .MaximumLength(64)
                .WithMessage("Name length cannot be more than 64");

        RuleFor(x => x.IconUrl)
            .NotNull()
            .NotEmpty()
            .WithMessage("Icon cannot be empty")
            .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
            .WithMessage("Icon value should be link")
                .MaximumLength(128)
                .WithMessage("Icon length cannot be more than 128");
    }
}
