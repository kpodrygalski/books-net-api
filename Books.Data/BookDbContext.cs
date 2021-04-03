using Books.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() { }

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
