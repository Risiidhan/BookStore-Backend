using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.DTO.Category;
using MediatR;

namespace BookStore.application.Features.Category.Request.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {
        
    }
}