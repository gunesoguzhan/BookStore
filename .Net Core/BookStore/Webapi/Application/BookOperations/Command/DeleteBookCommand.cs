using Webapi.Data;

namespace Webapi.Application.BookOperations.Command
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var entity = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (entity is null)
                throw new InvalidOperationException("Book is not exist.");
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }
    }
}