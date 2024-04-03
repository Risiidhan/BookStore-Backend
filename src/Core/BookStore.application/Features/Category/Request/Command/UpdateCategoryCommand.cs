using BookStore.application.DTO.Category;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Category.Request.Command
{
    public class UpdateCategoryCommand: IRequest<BaseCommandResponse>
    {
        public CategoryUpdateDto CategoryUpdateDto { get; set; } = null!;
    }
}