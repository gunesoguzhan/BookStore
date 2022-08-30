using Webapi.Application.BookOperations.Query;
using FluentValidation;

namespace Webapi.Validation.Book.Query
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}