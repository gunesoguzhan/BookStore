using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Book;

namespace Webapi.Application.BookOperations.Command
{
    public class UpdateBookCommand
    {
        public CommandBookViewModel Model { get; set; }
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entity = _context.Books.FirstOrDefault(x => x.Id == BookId);
            if (entity is null)
                throw new InvalidOperationException("Book is not exist.");
            if (_context.Books.Where(x => x.Title == Model.Title).Any())
                throw new InvalidOperationException("Book is already exist.");
            entity.Title = string.IsNullOrEmpty(Model.Title) ? entity.Title : Model.Title;
            entity.GenreId = Model.GenreId == default ? entity.GenreId : Model.GenreId;
            entity.PageCount = Model.PageCount == default ? entity.PageCount : Model.PageCount;
            entity.PublishDate = Model.PublishDate == default
                ? entity.PublishDate : Model.PublishDate;
            _context.SaveChanges();
        }
    }
}