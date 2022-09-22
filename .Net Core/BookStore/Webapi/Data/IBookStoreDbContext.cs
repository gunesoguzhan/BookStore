using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.Data
{
    public interface IBookStoreDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        public int SaveChanges();
    }
}