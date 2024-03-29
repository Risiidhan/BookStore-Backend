using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using BookStore.domain.Models;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookModel = _mapper.Map<domain.Models.Book>(request.BookCreateDto);
            var createdBook = await _bookRepository.AddAsync(bookModel);
            return _mapper.Map<BookDto>(createdBook);
        }
    }
}