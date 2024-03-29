using BookStore.application.DTO.Book;
using MediatR;

namespace BookStore.application.Features.Book.Request.Queries
{
    public class GetBookListRequest : IRequest<List<BookListDto>>
    {
    }
}