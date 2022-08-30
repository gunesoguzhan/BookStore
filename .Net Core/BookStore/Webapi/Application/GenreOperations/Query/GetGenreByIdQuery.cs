using AutoMapper;
using Webapi.Data;
using Webapi.ViewModels.Genre;

namespace Webapi.Application.GenreOperations.Query
{
    public class GetGenreByIdQuery
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QueryGenreViewModel Handle()
        {
            var entity = _context.Genres.SingleOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Genre mevcut değil.");
            QueryGenreViewModel model = _mapper.Map<QueryGenreViewModel>(entity);
            return model;
        }
    }
}