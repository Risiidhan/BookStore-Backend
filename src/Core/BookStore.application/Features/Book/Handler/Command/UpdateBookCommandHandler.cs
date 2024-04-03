using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.DTO.Book.Validator;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateBookCommandHandler(
            IBookRepository bookRepository,
            IMapper mapper,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository)
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new BookUpdateDtoValidator(_bookRepository, _authorRepository, _categoryRepository);
            var result = await validator.ValidateAsync(request.BookUpdateDto);
            if (!result.IsValid)
            {
                res.Success = false;
                res.Message = "Update Failed";
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var bookModel = await _bookRepository.GetAsync(request.BookUpdateDto.Id);
            bookModel = _mapper.Map(request.BookUpdateDto, bookModel);
            var updatedBook = await _bookRepository.UpdateAsync(bookModel);
            
            res.Id = updatedBook.Id;
            res.Success = false;
            res.Message = "Update Successfully";
            return res;
        }
    }
}