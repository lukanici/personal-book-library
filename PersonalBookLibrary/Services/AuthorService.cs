using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBookLibrary.Data;
using PersonalBookLibrary.Exceptions;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Author>> GetAllAuthorsAsync()
        {
            return await _repository.GetAll();
        }
    }
}
