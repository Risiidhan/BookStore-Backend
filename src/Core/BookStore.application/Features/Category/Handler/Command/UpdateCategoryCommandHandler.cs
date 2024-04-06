using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.DTO.Category.Validator;
using BookStore.application.Features.Category.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository category, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;

        }
        public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new CategoryUpdateDtoValidator(_categoryRepository);
            var result = await validator.ValidateAsync(request.CategoryUpdateDto);
            if (!result.IsValid)
            {
                res.Success = false;
                res.Message = "Update Failed";
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var categoryModel = await _categoryRepository.GetAsync(request.CategoryUpdateDto.Id);
            categoryModel = _mapper.Map(request.CategoryUpdateDto, categoryModel);
            var updatedCategory = await _categoryRepository.UpdateAsync(categoryModel!);

            res.Id = updatedCategory.Id;
            res.Success = false;
            res.Message = "Update Successfully";
            res.Result = updatedCategory;
            return res;
        }
    }
}