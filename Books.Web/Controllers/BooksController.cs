using System;
using System.Collections;
using System.Threading.Tasks;
using Books.Data.Models;
using Books.Services.Interfaces;
using Books.Web.RequestsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Books.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("books-list")]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("book/{bookId}/details")]
        public async Task<ActionResult<Book>> GetBookByIdAsync([FromRoute] int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [Route("book/create")]
        public async Task<ActionResult<Book>> CreateBookAsync([FromBody] BookRequestModel bookRequestModel)
        {
            var book = new Book
            {
                Title = bookRequestModel.Title,
                AuthorId = bookRequestModel.AuthorId,
                PageNumbers = bookRequestModel.PageNumbers

            };

            await _bookService.CreateBookAsync(book);

            return Ok($"Book {book.Title} created!");
        }

        [HttpDelete]
        [Route("book/{bookId}/delete")]
        public async Task<ActionResult<Book>> DeleteBookByIdAsync(int bookId)
        {
            await _bookService.DeleteBookByIdAsync(bookId);
            return Ok($"Book with ID = {bookId} was removed!");
        }

        [HttpGet]
        [Route("where/authorId/{authorId}")]
        public async Task<ActionResult<Book>> GetBookByAuthorId([FromRoute] int authorId)
        {
            var books = await _bookService.GetBooksByAuthorId(authorId);
            return Ok(books);
        }
    }
}
