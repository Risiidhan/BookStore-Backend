using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.Interface;
using FluentValidation;

namespace BookStore.application.DTO.Category.Validator
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryUpdateDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new ICategoryValidator());

             RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required!")
                .MustAsync(async (id, token) =>
                {
                    var categoryExists = await _categoryRepository.GetAsync(id);
                    return categoryExists != null;
                });
        }
    }
}