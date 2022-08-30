using Webapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Data
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}