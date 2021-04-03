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
        public ActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("book/{bookId}/details")]
        public ActionResult GetBookById([FromRoute] int bookId)
        {
            var book = _bookService.GetBookById(bookId);
            return Ok(book);
        }

        [HttpPost]
        [Route("book/create")]
        public ActionResult CreateBook([FromBody] BookRequestModel bookRequestModel)
        {
            var now = DateTime.UtcNow;

            var book = new Book
            {
                Title = bookRequestModel.Title,
                Author = bookRequestModel.Author,
                PageNumbers = bookRequestModel.PageNumbers,
                CreatedOn = now,
                UpdatedOn = now
            };

            _bookService.CreateBook(book);

            return Ok($"Book {book.Title} by {book.Author} was created succesfully on: {book.CreatedOn} !");
        }

        [HttpDelete]
        [Route("book/{bookId}/delete")]
        public ActionResult DeleteBookById(int bookId)
        {
            _bookService.DeleteBookById(bookId);
            return Ok($"Book with ID = {bookId} was removed!");
        }

        [HttpPost]
        [Route("book/create-async")]
        public async Task<ActionResult<Book>> CreateBookAsync([FromBody] BookRequestModel bookRequestModel)
        {
            var book = new Book
            {
                Title = bookRequestModel.Title,
                Author = bookRequestModel.Author,
                PageNumbers = bookRequestModel.PageNumbers
                
            };

            await _bookService.CreateBookAsync(book);

            return Ok($"Book create via async method");
        }

    }
}
