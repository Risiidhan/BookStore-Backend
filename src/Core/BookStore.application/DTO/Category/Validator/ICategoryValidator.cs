using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BookStore.application.DTO.Category.Validator
{
    public class ICategoryValidator : AbstractValidator<ICategoryValidatorDto>
    {
        public ICategoryValidator()
        {
             RuleFor(p =>p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .MaximumLength(20).WithMessage("{PropertyName} should be less than {ComparisonValue}")
                .MinimumLength(2).WithMessage("{PropertyName} should be more than {ComparisonValue}");
        }
    }
}