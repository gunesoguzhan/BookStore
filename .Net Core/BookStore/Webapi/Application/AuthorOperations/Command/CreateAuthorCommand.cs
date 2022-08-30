using AutoMapper;
using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Author;

namespace Webapi.Application.AuthorOperations.Command
{
    public class CreateAuthorCommand
    {
        public CommandAuthorViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entity = _context.Authors.FirstOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (entity is not null)
                throw new InvalidOperationException("Author is already exist.");
            Author author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}