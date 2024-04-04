using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.Interface;
using BookStore.domain.Models;
using BookStore.infrastructure.Data;

namespace BookStore.infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
        
    }
}