using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Data.Models;

namespace Books.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAuthorsAsync();
        public Task<Author> GetAuthorByIdAsync(int authorId);
        public Task AddAuthorAsync(Author author);
        public Task DeleteAuthorByIdAsync(int authorId);
    }
}
