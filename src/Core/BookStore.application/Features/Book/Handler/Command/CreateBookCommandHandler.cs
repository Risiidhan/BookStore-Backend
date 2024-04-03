using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.DTO.Book.Validator;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using BookStore.domain.Models;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateBookCommandHandler(
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
        public async Task<BaseCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new BookCreateDtoValidator(_authorRepository, _categoryRepository);
            var result = await validator.ValidateAsync(request.BookCreateDto);
            if (!result.IsValid)
            {
                res.Success = false;
                res.Message = "Creation Failed";
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var bookModel = _mapper.Map<domain.Models.Book>(request.BookCreateDto);
            var createdBook = await _bookRepository.AddAsync(bookModel);
            
            res.Id = createdBook.Id;
            res.Success = true;
            res.Message = "Created Failed";
            return res;
        }
    }
}