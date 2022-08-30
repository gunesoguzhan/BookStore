using Webapi.Application.GenreOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Genre.Command
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}