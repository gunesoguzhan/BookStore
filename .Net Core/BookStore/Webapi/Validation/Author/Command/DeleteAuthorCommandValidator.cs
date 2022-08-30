using Webapi.Application.AuthorOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Author.Command
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}