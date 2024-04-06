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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository category, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;

        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new CategoryCreateDtoValidator();
            var result = await validator.ValidateAsync(request.CategoryCreateDto);
            if (!result.IsValid)
            {
                res.Success = false;
                res.Message = CommonMessage.CreationFailed;
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var CategoryModel = _mapper.Map<domain.Models.Category>(request.CategoryCreateDto);
            var createdCategory = await _categoryRepository.AddAsync(CategoryModel);

            res.Id = createdCategory.Id;
            res.Success = true;
            res.Message = CommonMessage.GetCreatedSuccessfully(createdCategory.Name);
            res.Result = createdCategory;
            return res;
        }
    }
}