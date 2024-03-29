using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookModel = _mapper.Map<domain.Models.Book>(request.BookUpdateDto);
            var updatedBook = await _bookRepository.UpdateAsync(bookModel);
            return _mapper.Map<BookDto>(updatedBook);
        }
    }
}