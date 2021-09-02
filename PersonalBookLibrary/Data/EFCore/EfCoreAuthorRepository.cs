using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Data.EFCore
{
    public class EfCoreAuthorRepository : EfCoreRepository<Author, AppDbContext>
    {
        public EfCoreAuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
