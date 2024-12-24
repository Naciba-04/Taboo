using FluentValidation;
using Taboo.DTOs.Words;
using Taboo.Enums;

namespace Taboo.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(32);

            RuleFor(x => x.BannedWords)
                .NotNull()
                .Must(x => x.Count() == (int)GameLevels.Hard)
                .WithMessage("You must write" + (int)GameLevels.Hard + "unique forbidden words");

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MaximumLength(32);

        }
    }
}
