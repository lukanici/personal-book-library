using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalBookLibrary.Exceptions;
using PersonalBookLibrary.Models;
using PersonalBookLibrary.Services;
using PersonalBookLibrary.ViewModels;

namespace PersonalBookLibrary.Controllers
{
    [Route("api/books")]
    [ApiController]
    [TypeFilter(typeof(BookExceptionFilter))]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public BooksController(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetBooks()
        {
            var books = await _service.GetAllBooksAsync();
            var bookViewModels = books.Select(b => _mapper.Map<BookViewModel>(b)).ToArray();
            return bookViewModels;
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> GetBook(int id)
        {
            var book = await _service.GetBookByIdAsync(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return bookViewModel;
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookFormViewModel bookFormViewModel)
        {
            var book = _mapper.Map<Book>(bookFormViewModel);
            book.Id = id;
            await _service.UpdateBookAsync(book);
            return NoContent();
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookViewModel>> PostBook(BookFormViewModel bookFormViewModel)
        {
            var book = _mapper.Map<Book>(bookFormViewModel);
            await _service.CreateBookAsync(book);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return CreatedAtAction("GetBook", new { id = book.Id }, bookViewModel);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookViewModel>> DeleteBook(int id)
        {
            var book = await _service.DeleteBookByIdAsync(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return bookViewModel;
        }
    }
}
