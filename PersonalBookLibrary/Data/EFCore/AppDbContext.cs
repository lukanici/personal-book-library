using System;
using Microsoft.EntityFrameworkCore;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Data.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
