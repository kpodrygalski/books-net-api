using System;
using Books.Data.Models;

namespace Books.Web.RequestsModels
{
    public class BookRequestModel
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PageNumbers { get; set; }
    }
}
