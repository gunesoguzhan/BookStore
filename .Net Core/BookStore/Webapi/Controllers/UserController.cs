using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.UserOperations.Command;
using Webapi.Application.UserOperations.Query;
using Webapi.Data;
using Webapi.TokenOperations.Models;
using Webapi.Validation.User.Command;
using Webapi.Validation.User.Query;
using Webapi.ViewModels.User;

namespace Webapi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(IMapper mapper, IBookStoreDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterUserViewModel model)
        {
            RegisterUserCommand command = new(_context, _mapper);
            command.Model = model;
            RegisterUserCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserViewModel model)
        {
            LoginUserQuery query = new(_context, _mapper, _configuration);
            query.Model = model;
            LoginUserQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            Token token = query.Handle();
            return Ok(token);
        }
    }
}