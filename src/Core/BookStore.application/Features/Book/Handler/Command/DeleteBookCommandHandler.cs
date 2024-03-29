using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var deletedBook = await _bookRepository.DeleteAsync(request.Id);
            return _mapper.Map<BookDto>(deletedBook);
        }
    }
}