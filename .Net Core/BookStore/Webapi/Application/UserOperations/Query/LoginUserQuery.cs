using AutoMapper;
using Webapi.Data;
using Webapi.TokenOperations;
using Webapi.TokenOperations.Models;
using Webapi.ViewModels.User;

namespace Webapi.Application.UserOperations.Query
{
    public class LoginUserQuery
    {
        public LoginUserViewModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginUserQuery(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == Model.Username && x.Password == Model.Password);

            if (user is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            ITokenHandler tokenHandler = new JwtTokenHandler(_configuration);
            return tokenHandler.CreateAccessToken(seconds: 10);
        }
    }
}