using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Services
{
    public interface IAuthorService
    {
        Task<ICollection<Author>> GetAllAuthorsAsync();
    }
}
