using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.Features.Category.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Command
{
    public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository category , IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;
            
        }
        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var CategoryModel = _mapper.Map<domain.Models.Category>(request.CategoryUpdateDto);
            var updatedCategory = await _categoryRepository.UpdateAsync(CategoryModel);
            return _mapper.Map<CategoryDto>(updatedCategory);
        }
    }
}