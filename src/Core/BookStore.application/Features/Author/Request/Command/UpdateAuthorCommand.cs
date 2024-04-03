using BookStore.application.DTO.Author;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Author.Request.Command
{
    public class UpdateAuthorCommand : IRequest<BaseCommandResponse>
    {
        public AuthorUpdateDto AuthorUpdateDto { get; set; } = null!;
    }
}