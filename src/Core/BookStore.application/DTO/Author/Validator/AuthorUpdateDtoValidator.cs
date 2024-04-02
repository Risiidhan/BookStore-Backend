using BookStore.application.Interface;
using FluentValidation;

namespace BookStore.application.DTO.Author.Validator
{
    public class AuthorUpdateDtoValidator: AbstractValidator<AuthorUpdateDto>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorUpdateDtoValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            Include(new IAuthorValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required!")
                .MustAsync(async(id,token) =>
                {
                    var authorExists = await _authorRepository.GetAsync(id);
                    return authorExists != null;
                });
        }
    }
}