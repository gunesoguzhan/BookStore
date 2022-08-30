using AutoMapper;
using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Book;

namespace Webapi.Application.BookOperations.Command
{
    public class CreateBookCommand
    {
        public CommandBookViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entity = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (entity is not null)
                throw new InvalidOperationException("Book is already exist.");

            Book book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}