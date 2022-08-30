using Webapi.Application.BookOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Book.Command
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).MinimumLength(4);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now.AddYears(-1).Date);
        }
    }
}