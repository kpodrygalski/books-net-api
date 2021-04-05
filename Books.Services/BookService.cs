using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Data;
using Books.Data.Models;
using Books.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _db;

        public BookService(BookDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _db.Books.FindAsync(bookId);
        }

        public async Task CreateBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBookByIdAsync(int bookId)
        {
            var book = await _db.Books.FindAsync(bookId);

            if (book != null)
            {
                _db.Remove(book);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Book with ID = {bookId} not exist in database!");
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId)
        {
            var books = await _db.Books.Include(book => book.Author).Where(x => x.AuthorId == authorId).ToListAsync();
            return books;
        }
    }
}
