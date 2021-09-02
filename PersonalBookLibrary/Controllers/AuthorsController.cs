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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAuthors()
        {
            var authors = await _service.GetAllAuthorsAsync();
            var authorViewModels = authors.Select(a => _mapper.Map<AuthorViewModel>(a)).ToArray();
            return authorViewModels;
        }
    }
}
