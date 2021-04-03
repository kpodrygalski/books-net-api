using System;
namespace Books.Web.RequestsModels
{
    public class BookRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageNumbers { get; set; }
    }
}
