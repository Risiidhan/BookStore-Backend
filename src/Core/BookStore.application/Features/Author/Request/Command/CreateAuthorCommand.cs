using BookStore.application.DTO.Author;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Author.Request.Command
{
    public class CreateAuthorCommand : IRequest<BaseCommandResponse>
    {
        public AuthorCreateDto AuthorCreateDto { get; set; } = null!;
    }
}