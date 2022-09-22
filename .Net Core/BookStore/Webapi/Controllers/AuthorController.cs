using AutoMapper;
using Webapi.Application.AuthorOperations.Command;
using Webapi.Application.AuthorOperations.Query;
using Webapi.Data;
using Webapi.Validation.Author.Command;
using Webapi.Validation.Author.Query;
using Webapi.ViewModels.Author;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var query = new GetAuthorsQuery(_context, _mapper);
            var books = query.Handle();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var query = new GetAuthorByIdQuery(_context, _mapper);
            query.Id = id;
            var validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var book = query.Handle();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CommandAuthorViewModel model)
        {
            var command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;
            var validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ModifyAuthor(int id, [FromBody] CommandAuthorViewModel model)
        {
            var command = new UpdateAuthorCommand(_context);
            command.Id = id;
            command.Model = model;
            var validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var command = new DeleteAuthorCommand(_context);
            command.Id = id;
            var validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}