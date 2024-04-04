using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.Interface;
using BookStore.domain.Models;
using BookStore.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.infrastructure.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Book>> GetBookDetailList()
        {
            return await _dbContext.Books.Include(a => a.Author).Include(c => c.Category).ToListAsync();
        }
        public async Task<Book?> GetBookDetailList(int id)
        {
            return await _dbContext.Books
                .Include(a => a.Author)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}