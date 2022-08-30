using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Author;

namespace Webapi.Application.AuthorOperations.Query
{
    public class GetAuthorByIdQuery
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QueryAuthorViewModel Handle()
        {
            var entity = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Book is not exist.");
            QueryAuthorViewModel model = _mapper.Map<QueryAuthorViewModel>(entity);
            return model;
        }
    }
}