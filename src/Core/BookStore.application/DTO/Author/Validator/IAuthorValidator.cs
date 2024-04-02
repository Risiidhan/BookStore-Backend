using FluentValidation;

namespace BookStore.application.DTO.Author.Validator
{
    public class IAuthorValidator : AbstractValidator<IAuthorValidatorDto>
    {
        public IAuthorValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .EmailAddress().WithMessage("Incorrect Email.");
            
            RuleFor(p =>p.Username)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .MaximumLength(20).WithMessage("{PropertyName} should be less than {ComparisonValue}")
                .MinimumLength(2).WithMessage("{PropertyName} should be more than {ComparisonValue}");
        }
    }
}