using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Application.BookOperations.Query
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QueryBookViewModel> Handle()
        {
            var enities = _context.Books.Include(x => x.Genre).ToList();
            List<QueryBookViewModel> models = _mapper.Map<List<QueryBookViewModel>>(enities);
            return models;
        }
    }
}