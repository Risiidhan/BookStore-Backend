using BookStore.application.DTO.Author;
using MediatR;

namespace BookStore.application.Features.Author.Request.Command
{
    public class CreateAuthorCommand : IRequest<AuthorDto>
    {
        public AuthorCreateDto AuthorCreateDto { get; set; } = null!;
    }
}