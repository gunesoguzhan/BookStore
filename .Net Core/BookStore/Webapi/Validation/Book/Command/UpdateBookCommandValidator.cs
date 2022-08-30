using Webapi.Application.BookOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Book.Command
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}