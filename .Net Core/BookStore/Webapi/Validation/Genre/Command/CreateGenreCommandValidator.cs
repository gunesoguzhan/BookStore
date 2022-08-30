using Webapi.Application.GenreOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Genre.Command
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            var conditions = new List<string>() { "true", "false" };
            RuleFor(command => command.Model.IsActive)
                .NotEmpty()
                .Must(x => conditions.Contains(x))
                .WithMessage("Please use only: " + conditions[0] + " or " + conditions[1] + ".");
        }
    }
}