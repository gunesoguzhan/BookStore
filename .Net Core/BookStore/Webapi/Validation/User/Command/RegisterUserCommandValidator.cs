using FluentValidation;
using Webapi.Application.UserOperations.Command;

namespace Webapi.Validation.User.Command
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(command => command.Model.UserName).NotEmpty();
            RuleFor(command => command.Model.Email).EmailAddress();
            RuleFor(command => command.Model.Password).NotEmpty();
        }
    }
}