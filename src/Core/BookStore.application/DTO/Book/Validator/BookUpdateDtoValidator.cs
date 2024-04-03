using BookStore.application.Interface;
using FluentValidation;

namespace BookStore.application.DTO.Book.Validator
{
    public class BookUpdateDtoValidator : AbstractValidator<BookUpdateDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookUpdateDtoValidator(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository)
        {

            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            Include(new IBookValidator(_authorRepository, _categoryRepository));

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required!")
                .MustAsync(async (id, token) =>
                {
                    var bookExists = await _bookRepository.GetAsync(id);
                    return bookExists != null;
                });
        }


    }
}