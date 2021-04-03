using System;
using System.Collections.Generic;
using Books.Data.Models;

namespace Books.Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int bookId);
        public void CreateBook(Book book);
        public void DeleteBookById(int bookId);
    }
}
