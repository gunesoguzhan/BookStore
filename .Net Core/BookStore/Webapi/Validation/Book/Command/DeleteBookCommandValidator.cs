using Webapi.Application.BookOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Book.Command
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}