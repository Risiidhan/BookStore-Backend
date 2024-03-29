
using BookStore.application.DTO.Book;
using MediatR;

namespace BookStore.application.Features.Book.Request.Queries
{
    public class GetBookRequest : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}