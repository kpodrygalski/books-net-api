using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageNumbers { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
