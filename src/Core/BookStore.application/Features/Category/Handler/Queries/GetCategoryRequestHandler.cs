using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.Features.Category.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryRequestHandler(ICategoryRepository category , IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;
            
        }
        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);
              if(category == null)
                throw new Exception();
              
            return _mapper.Map<CategoryDto>(category);
        }
    }
}