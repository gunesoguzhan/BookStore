using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Genre;

namespace Webapi.Application.GenreOperations.Query
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QueryGenreViewModel> Handle()
        {
            var entities = _context.Genres.Where(x => x.IsActive == true).ToList();
            List<QueryGenreViewModel> models = _mapper.Map<List<QueryGenreViewModel>>(entities);
            return models;
        }
    }
}