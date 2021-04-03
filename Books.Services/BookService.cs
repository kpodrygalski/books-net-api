using System;
using System.Collections.Generic;
using System.Linq;
using Books.Data;
using Books.Data.Models;
using Books.Services.Interfaces;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _db;

        public BookService(BookDbContext db)
        {
            _db = db;
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _db.Books.Find(bookId);
        }

        public void CreateBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBookById(int bookId)
        {
            var book = _db.Books.Find(bookId);

            if (book != null)
            {
                _db.Remove(bookId);
                _db.SaveChanges();
            }else
            {
                throw new InvalidOperationException("Book not exist!");
            }
        }
    }
}
