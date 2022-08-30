using Webapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Data
{
    class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() || context.Genres.Any() || context.Authors.Any())
                    return;
                context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth",
                        IsActive = true
                    },
                    new Genre()
                    {
                        Name = "Science Fiction",
                        IsActive = true
                    },
                    new Genre()
                    {
                        Name = "Noval",
                        IsActive = false
                    }
                );
                context.Authors.AddRange(
                    new Author()
                    {
                        Name = "Frank",
                        Surname = "Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    },
                    new Author()
                    {
                        Name = "Eric",
                        Surname = "Ries",
                        BirthDate = new DateTime(1978, 09, 22)
                    },
                    new Author()
                    {
                        Name = "Charlotte Perkins",
                        Surname = "Gilman",
                        BirthDate = new DateTime(1860, 07, 03)
                    }
                );
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
                context.SaveChanges();
            }
        }
    }
}