using AutoMapper;
using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Genre;

namespace Webapi.Application.GenreOperations.Command
{
    public class CreateGenreCommand
    {
        public CommandGenreViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entity = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (entity is not null)
                throw new InvalidOperationException("Genre is already exist.");
            Genre genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}