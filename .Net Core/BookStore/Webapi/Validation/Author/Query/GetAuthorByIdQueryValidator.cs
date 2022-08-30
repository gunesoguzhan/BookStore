using Webapi.Application.AuthorOperations.Query;
using FluentValidation;

namespace Webapi.Validation.Author.Query
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}