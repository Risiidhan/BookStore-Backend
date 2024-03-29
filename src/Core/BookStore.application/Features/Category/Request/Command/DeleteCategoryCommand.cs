using BookStore.application.DTO.Category;
using MediatR;

namespace BookStore.application.Features.Category.Request.Command
{
    public class DeleteCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}