
using BookStore.application.Interface;
using FluentValidation;

namespace BookStore.application.DTO.Book.Validator
{
    public class IBookValidator : AbstractValidator<IBookValidatorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;


        public IBookValidator(IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            RuleFor(p => p.Price)
                .NotNull().WithMessage("{PropertyName} is required!");
            
            RuleFor(p =>p.QuantityAvailable)
                .NotNull().WithMessage("{PropertyName} is required!")
                .GreaterThan(1).WithMessage("{PropertyName} should be more than {ComparisonValue}");

            RuleFor(p => p.AuthorID)
                .NotNull().WithMessage("{PropertyName} is required!")
                .MustAsync(async(id,token) =>
                {
                    var authorExists = await _authorRepository.GetAsync(id);
                    return authorExists != null;
                });

              RuleFor(p => p.CategoryID)
                .NotNull().WithMessage("{PropertyName} is required!")
                .MustAsync(async(id,token) =>
                {
                    var categoryExists = await _categoryRepository.GetAsync(id);
                    return categoryExists != null;
                });
        }

    }
}