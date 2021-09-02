using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Services
{
    public interface IBookService
    {
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
        Task CreateBookAsync(Book book);
        Task<Book> DeleteBookByIdAsync(int id);
    }
}
