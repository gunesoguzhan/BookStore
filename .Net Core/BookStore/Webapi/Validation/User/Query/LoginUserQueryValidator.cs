using FluentValidation;
using Webapi.Application.UserOperations.Query;

namespace Webapi.Validation.User.Query
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(query => query.Model.Username).NotEmpty();
            RuleFor(query => query.Model.Password).NotEmpty();
        }
    }
}