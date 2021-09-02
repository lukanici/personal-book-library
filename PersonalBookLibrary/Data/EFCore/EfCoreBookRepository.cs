using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalBookLibrary.Models;

namespace PersonalBookLibrary.Data.EFCore
{
    public class EfCoreBookRepository : EfCoreRepository<Book, AppDbContext>
    {
        public EfCoreBookRepository(AppDbContext context) : base(context)
        {
        }

        public async override Task<Book> Get(int id)
        {
            return await context.Book
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async override Task<List<Book>> GetAll()
        {
            return await context.Book
                .Include(x => x.Author)
                .ToListAsync();
        }
    }
}
