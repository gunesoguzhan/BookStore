using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using Webapi.Application.BookOperations.Command;
using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Book;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.BookOperations.Command
{
    public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange
            var book = new Book()
            {
                Title = "Test_WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn",
                AuthorId = 1,
                GenreId = 1,
                PageCount = 100,
                PublishDate = new DateTime(2019, 05, 08)
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CommandBookViewModel()
            {
                Title = "Test_WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 200,
                GenreId = 1,
                PublishDate = new DateTime(10, 12, 1983),
                AuthorId = 1
            };

            // act & assert
            // var exception = Assert.Throws<InvalidOperationException>(() => command.Handle());
            // Assert.Equal("Book is already exist.", exception.Message);
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book is already exist.");
        }

        [Fact]
        public void WhenGivenInputIsValid_Book_ShouldBeCreated()
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CommandBookViewModel()
            {
                Title = "Test_WhenGivenInputIsValid_Book_ShouldBeCreated",
                PageCount = 155,
                GenreId = 7,
                PublishDate = new DateTime(10, 12, 1983),
                AuthorId = 2
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();
            var book = _context.Books.SingleOrDefault(x => x.Title == command.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(command.Model.PageCount);
            book.GenreId.Should().Be(command.Model.GenreId);
            book.PublishDate.Should().Be(command.Model.PublishDate);
            book.AuthorId.Should().Be(command.Model.AuthorId);

        }
    }
}