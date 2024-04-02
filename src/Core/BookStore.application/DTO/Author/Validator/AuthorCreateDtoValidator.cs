using FluentValidation;

namespace BookStore.application.DTO.Author.Validator
{
    public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateDtoValidator()
        {
            Include(new IAuthorValidator());
        }
    }
}