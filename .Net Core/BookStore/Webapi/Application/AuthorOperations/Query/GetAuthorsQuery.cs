using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Author;

namespace Webapi.Application.AuthorOperations.Query
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QueryAuthorViewModel> Handle()
        {
            var entities = _context.Authors.ToList();
            List<QueryAuthorViewModel> models = _mapper.Map<List<QueryAuthorViewModel>>(entities);
            return models;
        }
    }
}