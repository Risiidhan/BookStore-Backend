using BookStore.application.DTO.Category;
using MediatR;

namespace BookStore.application.Features.Category.Request.Command
{
    public class UpdateCategoryCommand: IRequest<CategoryDto>
    {
        public CategoryUpdateDto CategoryUpdateDto { get; set; } = null!;
    }
}