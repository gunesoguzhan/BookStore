using Webapi.Application.AuthorOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Author.Command
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}