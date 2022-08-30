using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Tests.WebApi.UnitTests.TestSetup;
using Webapi.Application.BookOperations.Command;
using Webapi.Data;
using Webapi.Validation.Book.Command;
using Webapi.ViewModels.Book;
using Xunit;

namespace Tests.WebApi.UnitTests.Validation.Book.Command
{
    public class CreateBookCommandValidatorTest
    {
        [Theory]
        // The Worst result
        [InlineData("", 0, 0, 0, 4)]
        // Title equals empty
        [InlineData("", 1, 1, 1, 1)]
        // Title equals one space
        [InlineData(" ", 1, 1, 1, 1)]
        // Title min length
        [InlineData("Lor", 1, 1, 1, 1)]
        // AuthorId equals zero
        [InlineData("Lord", 0, 1, 1, 1)]
        // AuthorId less than zero
        [InlineData("Lord", -1, 1, 1, 1)]
        // GenreId equals zero
        [InlineData("Lord", 1, 0, 1, 1)]
        // GenreId less than zero
        [InlineData("Lord", 1, -1, 1, 1)]
        // PageCount equals zero
        [InlineData("Lord", 1, 1, 0, 1)]
        // PageCount less than zero
        [InlineData("Lord", 1, 1, -1, 1)]
        // Valid result
        [InlineData("Lord Of The Rings", 1, 1, 1, 0)]
        [InlineData("Lord", 1, 1, 1, 0)]
        [InlineData("Lord", 1, 1, 1, 0)]
        public void WhenInvalidBookPropertiesGiven_Validator_ShouldBeReturnErrors(string title, int authorId, int genreId, int pageCount, int expectedErrorsCount)
        {
            // arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CommandBookViewModel()
            {
                Title = title,
                AuthorId = authorId,
                GenreId = genreId,
                PageCount = pageCount,
                PublishDate = DateTime.Now.AddYears(-2).Date
            };

            // act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            // assert
            // Assert.Equal(expectedErrorsCount, result.Errors.Count());
            result.Errors.Count().Should().Be(expectedErrorsCount);
        }

        [Fact]
        public void WhenInvalidBookPublishDateGiven_Validator_ShouldBeReturnErrors()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CommandBookViewModel()
            {
                Title = "Test_WhenInvalidBookPublishDateGiven_Validator_ShouldBeReturnErrors",
                AuthorId = 1,
                GenreId = 1,
                PageCount = 100,
                PublishDate = DateTime.Now.Date
            };

            // act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            FluentActions.Invoking(() => validator.ValidateAndThrow(command)).Should().Throw<ValidationException>();
        }
    }
}