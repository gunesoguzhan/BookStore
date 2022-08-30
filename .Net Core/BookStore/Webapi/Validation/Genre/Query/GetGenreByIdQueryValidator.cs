using Webapi.Application.GenreOperations.Query;
using FluentValidation;

namespace Webapi.Validation.Genre.Query
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}