using Webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Application.GenreOperations.Command
{
    public class DeleteGenreCommand
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var entity = _context.Genres.Include(x => x.Books).SingleOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Genre is not exist..");
            if (entity.Books.Any())
                throw new InvalidOperationException("Genre has books.");
            _context.Genres.Remove(entity);
            _context.SaveChanges();
        }
    }
}