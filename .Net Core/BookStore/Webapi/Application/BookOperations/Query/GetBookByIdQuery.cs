using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Application.BookOperations.Query
{
    public class GetBookByIdQuery
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QueryBookViewModel Handle()
        {
            var entity = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.Id == BookId);
            if (entity is null)
                throw new InvalidOperationException("Book is not exists.");
            QueryBookViewModel model = _mapper.Map<QueryBookViewModel>(entity);
            return model;
        }
    }
}