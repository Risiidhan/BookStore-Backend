using BookStore.application.DTO.Category;
using MediatR;

namespace BookStore.application.Features.Category.Request.Queries
{
    public class GetCategoryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}