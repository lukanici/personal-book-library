using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonalBookLibrary.Data;

namespace PersonalBookLibrary.Models
{
    public class Book : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookGenre Genre { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
