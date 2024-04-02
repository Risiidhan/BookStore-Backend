using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.application.DTO.Category
{
    public class CategoryUpdateDto : ICategoryValidatorDto
    {
        public int Id { get; set; }
    }
}