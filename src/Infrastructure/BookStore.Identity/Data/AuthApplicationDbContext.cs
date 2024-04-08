using BookStore.domain.Models;
using BookStore.Identity.configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Identity.Data
{
    public class AuthApplicationDbContext : IdentityDbContext<AppUser>
    {
        public AuthApplicationDbContext(DbContextOptions<AuthApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}