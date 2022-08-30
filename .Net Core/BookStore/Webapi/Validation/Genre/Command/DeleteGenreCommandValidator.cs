using Webapi.Application.GenreOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Genre.Command
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}