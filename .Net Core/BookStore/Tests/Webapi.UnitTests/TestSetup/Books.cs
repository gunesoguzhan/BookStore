using Webapi.Data;
using Webapi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book()
                {
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12),
                    AuthorId = 2
                },
                new Book()
                {
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 146,
                    PublishDate = new DateTime(1915, 05, 23),
                    AuthorId = 3
                },
                new Book()
                {
                    Title = "Dune",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21),
                    AuthorId = 1
                }
            );
        }
    }
}