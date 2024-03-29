using BookStore.application.DTO.Author;
using MediatR;

namespace BookStore.application.Features.Author.Request.Command
{
    public class UpdateAuthorCommand : IRequest<AuthorDto>
    {
        public AuthorUpdateDto AuthorUpdateDto { get; set; } = null!;
    }
}