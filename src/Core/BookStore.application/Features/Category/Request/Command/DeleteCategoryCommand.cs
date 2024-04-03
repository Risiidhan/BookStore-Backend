using BookStore.application.DTO.Category;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Category.Request.Command
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}