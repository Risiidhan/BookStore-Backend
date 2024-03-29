
using BookStore.application.DTO.Book;
using MediatR;

namespace BookStore.application.Features.Book.Request.Command
{
    public class UpdateBookCommand : IRequest <BookDto>
    {
        public BookUpdateDto BookUpdateDto { get; set; } = null!;
    }
}