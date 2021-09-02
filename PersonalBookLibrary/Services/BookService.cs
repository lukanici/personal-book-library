using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalBookLibrary.Data;
using PersonalBookLibrary.Exceptions;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task CreateBookAsync(Book book)
        {
            var books = await _repository.GetAll();
            var bookAlreadyExists = books.Any(b => b.Title.Replace(" ", "").ToLower() == book.Title.Replace(" ", "").ToLower() && b.AuthorId == book.AuthorId);
            if (bookAlreadyExists)
            {
                throw new BookAlreadyExistsException("Book with same title and author already exists");
            }
            await _repository.Add(book);
        }

        public async Task<Book> DeleteBookByIdAsync(int id)
        {
            var book = await _repository.Delete(id);
            if (book == null)
            {
                throw new BookNotFoundException($"Book with id of {id} not found");
            }
            return book;
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _repository.Get(id);
            if (book == null)
            {
                throw new BookNotFoundException($"Book with id of {id} not found");
            }
            return book;
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _repository.Update(book);
        }
    }
}
