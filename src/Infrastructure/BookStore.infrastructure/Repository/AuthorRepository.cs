
using BookStore.application.Interface;
using BookStore.domain.Models;
using BookStore.infrastructure.Data;

namespace BookStore.infrastructure.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}