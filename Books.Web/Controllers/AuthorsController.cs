using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Data;
using Books.Data.Models;
using Books.Services.Interfaces;
using Books.Web.RequestsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Books.Web.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorService _authorService;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        [HttpGet]
        [Route("authors-list")]
        public ActionResult GetAuthorsList()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet]
        [Route("author/{authorId}/details")]
        public ActionResult GetAuthorById([FromRoute] int authorId)
        {
            var author = _authorService.GetAuthorById(authorId);
            return Ok(author);
        }

        [HttpPost]
        [Route("author/create")]
        public async Task<ActionResult<Author>> CreateAuthorAsync(AuthorRequestModel authorRequestModel)
        {
            var author = new Author
            {
                Name = authorRequestModel.Name,
                Surname = authorRequestModel.Surname
            };
            
            await _authorService.AddAuthorAsync(author);

            return Ok($"{author.Name} {author.Surname} was created!");
        }

        [HttpDelete]
        [Route("author/{authorId}/delete")]
        public async Task<ActionResult> DeleteAuthorById([FromRoute] int authorId)
        {
            await _authorService.DeleteAuthorById(authorId);

            return Ok($"Author with ID = {authorId} was removed!");
        }
    }
}