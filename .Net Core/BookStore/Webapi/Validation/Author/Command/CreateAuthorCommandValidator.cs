using Webapi.Application.AuthorOperations.Command;
using FluentValidation;

namespace Webapi.Validation.Author.Command
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.BirthDate).LessThan(DateTime.Now.AddYears(-10).Date);
        }
    }
}