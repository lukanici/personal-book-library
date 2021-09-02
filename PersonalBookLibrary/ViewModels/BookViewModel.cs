using System;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookGenre Genre { get; set; }
        public AuthorViewModel Author { get; set; }
        public DateTime ModifiedUtc { get; set; }
    }
}
