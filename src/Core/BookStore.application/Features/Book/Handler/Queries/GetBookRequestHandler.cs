using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Queries
{
    public class GetBookRequestHandler : IRequestHandler<GetBookRequest, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookDetailList(request.Id);
            if(book == null)
                throw new Exception();
                
            return _mapper.Map<BookDto>(book);
        }
    }
}