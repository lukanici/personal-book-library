using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.ViewModels
{
    public class BookFormViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public BookGenre Genre { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
