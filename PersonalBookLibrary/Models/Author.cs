using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalBookLibrary.Data;

namespace PersonalBookLibrary.Models
{
    public class Author : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
