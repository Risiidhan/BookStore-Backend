using BookStore.application.DTO.Book;
using MediatR;

namespace BookStore.application.Features.Book.Request.Command
{
    public class DeleteBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; } 
    }
}