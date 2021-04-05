using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.Data;
using Books.Data.Models;
using Books.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookDbContext _db;

        public AuthorService(BookDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            var author = await _db.Authors.FindAsync(authorId);

            if (author != null) return author;
            throw new InvalidOperationException($"Can't find author with ID = {authorId} !");
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _db.AddAsync(author);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAuthorByIdAsync(int authorId)
        {
            var author = await _db.Authors.FindAsync(authorId);

            if (author != null)
            {
                _db.Remove(author);
                await _db.SaveChangesAsync();
            }else
            {
                throw new InvalidOperationException($"Can't find author with ID = {authorId} in database!");
            }
        }
    }
}
