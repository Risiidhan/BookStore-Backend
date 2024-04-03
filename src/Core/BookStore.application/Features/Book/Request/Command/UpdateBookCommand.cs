
using BookStore.application.DTO.Book;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Book.Request.Command
{
    public class UpdateBookCommand : IRequest <BaseCommandResponse>
    {
        public BookUpdateDto BookUpdateDto { get; set; } = null!;
    }
}