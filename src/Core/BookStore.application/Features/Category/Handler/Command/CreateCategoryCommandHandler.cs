using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.DTO.Category.Validator;
using BookStore.application.Features.Category.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository category, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;

        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CategoryCreateDtoValidator();
            var result = await validator.ValidateAsync(request.CategoryCreateDto);
            if (!result.IsValid)
                throw new Exception();

            var CategoryModel = _mapper.Map<domain.Models.Category>(request.CategoryCreateDto);
            var createdCategory = await _categoryRepository.AddAsync(CategoryModel);
            return _mapper.Map<CategoryDto>(createdCategory);
        }
    }
}