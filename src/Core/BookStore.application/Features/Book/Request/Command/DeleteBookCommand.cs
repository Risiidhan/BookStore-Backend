using BookStore.application.DTO.Book;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Book.Request.Command
{
    public class DeleteBookCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; } 
    }
}