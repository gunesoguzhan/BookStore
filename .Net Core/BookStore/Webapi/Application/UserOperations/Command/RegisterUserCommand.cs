using AutoMapper;
using Webapi.Data;
using Webapi.Entities;
using Webapi.ViewModels.User;

namespace Webapi.Application.UserOperations.Command
{
    public class RegisterUserCommand
    {
        public RegisterUserViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public RegisterUserCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == Model.UserName);
            if (user is not null)
            {
                throw new InvalidOperationException("User is already exists.");
            }
            _context.Users.Add(_mapper.Map<User>(Model));
            _context.SaveChanges();
        }
    }
}