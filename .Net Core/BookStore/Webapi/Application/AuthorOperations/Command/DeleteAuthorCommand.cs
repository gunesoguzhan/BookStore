using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Author;

namespace Webapi.Application.AuthorOperations.Command
{
    public class DeleteAuthorCommand
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var entity = _context.Authors.FirstOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Author is not exist.");
            if (_context.Books.Where(x => x.AuthorId == Id).Any())
                throw new InvalidOperationException("Author has books.");
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }
    }
}