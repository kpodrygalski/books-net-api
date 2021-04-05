using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Data.Models;

namespace Books.Services.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync(); // GET ALL BOOKS
        public Task<Book> GetBookByIdAsync(int bookId); // GET BOOK BY ID ASYNC
        public Task CreateBookAsync(Book book); // CREATE NEW BOOK ASYNC
        public Task DeleteBookByIdAsync(int bookId); // DELETE BOOK ASYNC
        public Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);  // GET ALL BOOK WHERE AUTOR ID = authorId
    }
}
