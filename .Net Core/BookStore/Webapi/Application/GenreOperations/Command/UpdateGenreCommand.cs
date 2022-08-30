using Webapi.Data;
using Webapi.ViewModels.Genre;

namespace Webapi.Application.GenreOperations.Command
{
    public class UpdateGenreCommand
    {
        public int Id { get; set; }
        public CommandGenreViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;

        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var entity = _context.Genres.SingleOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Genre is not exist.");
            if (_context.Genres.Where(x => x.Name == Model.Name).Any())
                throw new InvalidOperationException("Genre is already exist.");
            entity.Name = string.IsNullOrEmpty(Model.Name) ? entity.Name : Model.Name;
            entity.IsActive = string.IsNullOrEmpty(Model.IsActive) ? entity.IsActive : Convert.ToBoolean(Model.IsActive);
            _context.SaveChanges();
        }
    }
}