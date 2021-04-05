using System.Threading.Tasks;
using Books.Data.Models;
using Books.Services.Interfaces;
using Books.Web.RequestsModels;
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
        public async Task<ActionResult<Author>> GetAuthorsList()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            if (authors == null) return NotFound();

            return Ok(authors);
        }

        [HttpGet]
        [Route("author/{authorId}/details")]
        public async Task<ActionResult<Author>> GetAuthorById([FromRoute] int authorId)
        {
            var author = await _authorService.GetAuthorByIdAsync(authorId);
            if (author == null) return NotFound();
            
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
            await _authorService.DeleteAuthorByIdAsync(authorId);

            return Ok($"Author with ID = {authorId} was removed!");
        }
    }
}