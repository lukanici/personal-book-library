using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Data.EFCore
{
    public class DataSeeder
    {
        public static void SeedBooks(DbContext context)
        {
            var now = DateTime.Now;
            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "Guillaume",
                    LastName = "Musso",
                    CreatedUtc = now,
                    ModifiedUtc = now
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Walter",
                    LastName = "Isaacson",
                    CreatedUtc = now,
                    ModifiedUtc = now
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Jamie",
                    LastName = "Oliver",
                    CreatedUtc = now,
                    ModifiedUtc = now
                }
            };
            context.AddRange(authors);

            var books = new List<Book>
            {
                new Book {
                    Title = "Central Park",
                    Description = "Central Park thriller by Guillaume Musso",
                    Genre = BookGenre.Horror,
                    CreatedUtc = now,
                    ModifiedUtc = now,
                    AuthorId = 1
                },
                new Book {
                    Title = "7 Ways",
                    Description = "7 Ways cookbook by Jamie Oliver",
                    Genre = BookGenre.Cookbook,
                    CreatedUtc = now,
                    ModifiedUtc = now,
                    AuthorId = 3
                },
                new Book {
                    Title = "Minute Meals",
                    Description = "Minute Meals cookbook by Jamie Oliver",
                    Genre = BookGenre.Cookbook,
                    CreatedUtc = now,
                    ModifiedUtc = now,
                    AuthorId = 3
                },
                new Book {
                    Title = "Steve Jobs",
                    Description = "Steve Jobs biography by Walter Isaacson",
                    Genre = BookGenre.Biography,
                    CreatedUtc = now,
                    ModifiedUtc = now,
                    AuthorId = 2
                },
                new Book {
                    Title = "The Reunion",
                    Description = "The Reunion thriller by Guillaume Musso",
                    Genre = BookGenre.Horror,
                    CreatedUtc = now,
                    ModifiedUtc = now,
                    AuthorId = 1
                }
            };
            context.AddRange(books);
            context.SaveChanges();
        }
    }
}
