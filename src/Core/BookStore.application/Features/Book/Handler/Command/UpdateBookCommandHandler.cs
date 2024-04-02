using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.DTO.Book.Validator;
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
            var validator = new BookUpdateDtoValidator(_bookRepository);
            var result = await validator.ValidateAsync(request.BookUpdateDto);
            if(!result.IsValid)
                throw new Exception();

            var bookModel = await _bookRepository.GetAsync(request.BookUpdateDto.Id);
            bookModel = _mapper.Map(request.BookUpdateDto, bookModel);
            var updatedBook = await _bookRepository.UpdateAsync(bookModel);
            return _mapper.Map<BookDto>(updatedBook);
        }
    }
}