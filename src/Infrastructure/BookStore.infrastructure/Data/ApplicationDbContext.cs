using BookStore.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books {get; set;}
        public DbSet<Author> Authors {get; set;}
        public DbSet<Category> Categorys {get; set;}


    }
}