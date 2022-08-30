using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.Author;

namespace Webapi.Application.AuthorOperations.Command
{
    public class UpdateAuthorCommand
    {
        public int Id { get; set; }
        public CommandAuthorViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var entity = _context.Authors.FirstOrDefault(x => x.Id == Id);
            if (entity is null)
                throw new InvalidOperationException("Author is not exist.");
            string name = string.IsNullOrEmpty(Model.Name) ? entity.Name : Model.Name;
            string surname = string.IsNullOrEmpty(Model.Surname) ? entity.Surname : Model.Surname;
            if (_context.Authors.Where(x => x.Id != Id && x.Name == name && x.Surname == surname).Any())
                throw new InvalidOperationException("Author is already exist.");
            entity.Name = name;
            entity.Surname = surname;
            entity.BirthDate = Model.BirthDate == default ? entity.BirthDate : Model.BirthDate;
            _context.SaveChanges();
        }
    }
}